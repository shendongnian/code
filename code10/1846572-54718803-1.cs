    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TankBehaviour : MonoBehaviour
    {
    
        public GameObject shellPrefab;
        public Transform fireTransform;
        private bool isFired = false;
        public float bulletSpeed;
    
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
    
            transform.position += transform.forward * y;
            transform.Rotate(0, x, 0);
    
            if (Input.GetKeyUp(KeyCode.Space) && !isFired)
            {
                Debug.Log("fire!");
                Fire();
            }
        }
    
        void Fire()
        {
            //isFired = true;
            GameObject shellInstance = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation) as GameObject;
    
            if (shellInstance)
            {
                shellInstance.tag = "Shell";
                Rigidbody shellRB = shellInstance.GetComponent<Rigidbody>();
                shellRB.AddForce(15f * transform.forward, ForceMode.Impulse);
                Debug.Log("velocity");
            }
        }
    }
