    public class ErrantMove : CharacterPhysic {
      
      private void Start ()
      {
         whatIsGround = LayerMask.GetMask("Ground");
         groundRadius = 0.01f;
      }
    
      private void FixedUpdate()
      {
         Debug.Log(IsGrounded());
      }
 
    }
