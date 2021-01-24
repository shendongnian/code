    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Rotateturret : MonoBehaviour
    {
    public enum RotateOnAxis { rotateOnX, rotateOnY, rotateOnZ };
    public bool randomRotation = false;
    [Range(0, 360)]
    public int rotationRange = 70;
    public int startRotation = 20; //create a startRotation value.
    public int currentRotation = 20; //create a currentRotation value in case you need to access it later.
    private void Update()
    {
        if (randomRotation == true)
        {
            var rr = Random.Range(-rotationRange, rotationRange);
            currentRotation = startRotation + rr; //Add the random value to the start value. This also works for negative values.
            transform.Rotate(Vector3.up, currentRotation); //use the combined value instead of just rr.
        }
    }
    }
