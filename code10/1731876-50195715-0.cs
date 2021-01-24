    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class FpsScoreScript : MonoBehaviour
    {
        public int points;
        public Transform destination;
        public bool teleported;
    
        public void Start()
        {
    
        }
    
        public void Update()
        {
            if (points == 7 && !teleported)
            {
              gameObject.transform.position = destination.position;
              teleported = true;
            }
    
        }
    }
