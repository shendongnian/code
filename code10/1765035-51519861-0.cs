    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Trigger1 : MonoBehaviour
    {
        // Drag your Leve2Win trigger into the following Inspector object slot.
        public Level2Win Trigger2;
    
        private void Awake()
        {
            Trigger2.enabled = false;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            Destroy(GameObject.Find("Block2"));
            Trigger2.enabled = true;
        }
    }
