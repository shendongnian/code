    public class CharacterPhysic : MonoBehaviour {
      . . .
      protected virtual void Start ()
      {
         whatIsGround = LayerMask.GetMask("Ground");
         groundRadius = 0.01f;
      }
      protected bool IsGrounded()
      {
         Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPoints.position, groundRadius, whatIsGround);
         return colliders.Length > 0;
      }
      . . .
    }
    public class ErrantMove : CharacterPhysic {
      
      protected override void Start()
      {
          base.Start();
      }
    
      private void FixedUpdate()
      {
         Debug.Log(IsGrounded());
      }
 
    }
