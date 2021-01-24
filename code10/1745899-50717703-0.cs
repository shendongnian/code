    public class MoveTo : MonoBehaviour
    {
        public Transform pointToGo;
        public float speed;
    
        public bool colliding = false;
    
        private void Update()
        {
            if (!colliding)
            {
                //Move
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, pointToGo.position, step);
            }
            
        }
    
        //Callback when enter the trigger
        private void OnTriggerEnter2D(Collider2D collision)
        {
            colliding = true;
    
        }
    }
