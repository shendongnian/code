    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Powerup : MonoBehaviour {
    
        public float multiplier = 3f;
        public float duration = 10f;
    
    
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                RaycastShooting.fireRate *= multiplier;
                Destroy(other);
                Invoke("Reset", duration); // Calls method Reset after a period of time
            }
        }
    
        void Reset()
        {
            RaycastShooting.fireRate = 4;
        }
    
    }
