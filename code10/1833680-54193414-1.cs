    using UnityEngine;
    
    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody rb;
    
        public float forwardForce = 300f;
        public float sidewaysForce = 200f;
    
        private Vector2 lastPosition;    
    
        // Update is called once per frame
        void Update()
        {
            // are you sure that you want to become faster and faster?
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
    
            if(Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);
    
                if(touch.phase == TouchPhase.Began)
                {
                    lastPosition = touch.position;
                }
                if(touch.phase == TouchPhase.Moved)
                {
                    // get the moved direction compared to the initial touch position
                    var direction = touch.position - lastPosition ;
    
                    // get the signed x direction
                    // if(direction.x >= 0) 1 else -1
                    var signedDirection = Mathf.Sign(direction.x);
    
                    // are you sure you want to become faster over time?
                    rb.AddForce(sidewaysForce * signedDirection * Time.deltaTime, 0, 0);
    
                    lastPosition = touch.position;
                }
            }
        }
    }
