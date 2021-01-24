        using UnityEngine;
        using System.Collections;
        public class ClassName : MonoBehaviour 
        {
        void Update()
        {
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed primary button.");
        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed secondary button.");
        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");
        }
        }
