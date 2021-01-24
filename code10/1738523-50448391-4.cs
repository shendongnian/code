    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float tilt;
        public Boundary boundary;
    
        void FixedUpdate ()
        {
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
    
            Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
            rigidbody.velocity = movement * speed;
    
            rigidbody.position = new Vector3 
            (
                Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
                0.0f, 
                5.0f 
            );
    
        }
    }
