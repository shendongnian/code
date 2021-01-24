    public class launch : MonoBehaviour
    {
        public GameObject Target;
        public float speed;
    void Update()
    {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        }
        void OnCollisionEnter(Collision collision)
        {
            // Only collide with your specific target
            if (collision.gameObject != Target) return;
        
            Destroy(Target);
            Destroy(this.gameObject);
        }
    }
    
