    public class SimplePlatformController : MonoBehaviour
    {
    
        // ...
        private int airJumpCount = 0; // Add this counter
    
        // ...
    
        // Update is called once per frame
        void Update()
        {
            grounded = Physics2D.Linecast(
                    transform.position, groundCheck.position, 
                    1 << LayerMask.NameToLayer("Ground"));
    
            if (Input.GetButtonDown("Jump") && grounded)
            {
                airJumpCount = 0;  
                jump = true;
                   
            }
    
            // Only enter the air jump block if we still have more air jumps
            if ( Input.GetButtonDown("Jump") && !grounded && airJumpCount < 1) 
            {
                airJumpCount++;
                jump = true;  
            }
        }
    
        // ...
    }
