    public class launch : MonoBehaviour
    {
        public Transform Target;
        public float speed;
    void Update()
    {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }
        //...
    }
    
