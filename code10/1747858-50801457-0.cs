    using UnityEngine;
    using UnityEngine.UI;     
    
    public class DistanceToCheckpoint : MonoBehaviour {
    
        // Reference to checkpoint position
        [SerializeField]
        private Transform checkpoint;
    
        // Calculated distance value
        private float distance;
    
        // Update is called once per frame
        private void Update()
        {
            // Calculate distance value between character and checkpoint
            distance = (checkpoint.transform.position - transform.position).magnitude;
    
            checkpoint.GetComponent<Renderer>().material.color = new Color(-(100 - distance), 0, 0);
        }
    
    }
