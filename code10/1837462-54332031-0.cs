    using UnityEngine;
    using System.Collections;
    
    public class PlayerControl : MonoBehaviour 
    {
        // Use this for initialization
        void FixedUpdate ()
        {
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
    
            Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
            rigidbody.velocity = movement;
        }
    }
