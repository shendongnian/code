    public class PlayerController : MonoBehaviour
    {
        public float speed;
    	//The tild factor
        public float tilt;
    	//The limit within the spaceship can move
        public Boundary boundary;
    
        void FixedUpdate ()
        {
    		//You will need to capture the screen touchs of the user for the inputs
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
    
    		//Applying the movement to the GameObject
            Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
            rigidbody.velocity = movement * speed;
    
    		//To ensure the GameObject doesnt move outside of the game boundary
            rigidbody.position = new Vector3 
            (
                Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
                0.0f, 
                Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
            );
    
    		//Here is where you apply the rotation 
            rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
        }
    }
