    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public static class keyitems
    {
        public static int keyCount;
    }
    public class keyitem : MonoBehaviour
    {
        public object GameVariables { get; private set; }
    
        void OnTriggerEnter(Collider collider)
        {
            {
                if (collider.gameObject.name == "Player")
                {
                    keyitems.keyCount += 2;
                    Destroy(gameObject);
                }
            }
        }
    }
