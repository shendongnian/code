    public class CharacterMovement : MonoBehaviour {
    
        public float speed = 5f;
        public bool touchingLeft;
        public bool touchingRight;
    
    
        void Start() {
    
    
        }
    
    
        void Update() {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.A) && !touchingLeft)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                
                touchingRight = false;
            }
            if (Input.GetKey(KeyCode.D) && !touchingRight)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                touchingLeft = false;
            }
        }
    
    
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "leftOffscreen")
            {
                touchingLeft = true;
            } 
            if else (col.gameObject.name == "rightOffscreen")
            {
                touchingRight = true;
            }
        }
    }
