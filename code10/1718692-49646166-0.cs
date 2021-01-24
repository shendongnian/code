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
                StartCoroutine(Pickup(other));
            }
        }
        IEnumerator Pickup(Collider player)
        {
            RaycastShooting.fireRate *= multiplier;
            Destroy(player.gameObject);              
            yield return new WaitForSeconds(duration);
            RaycastShooting.fireRate = 4;    
        }
    }
