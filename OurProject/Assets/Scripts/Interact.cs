using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    private GameObject click;
    private Collider bed;
    List<Collider> colliders;
    private void Start()
    {
        click = GameObject.FindWithTag("Click");
        bed = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bed != null)
        {
            SceneManager.LoadScene(1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bed"))
        {
            other.GetComponent<Outline>().enabled = true;
            click.SetActive(true);
            bed = other;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bed"))
        { 
            other.GetComponent<Outline>().enabled = false;
            click.SetActive(false);
            bed = null;
        }
    }
}
