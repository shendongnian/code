    public class chasePlayer : MonoBehaviour
    {
        public Transform target;
        public float speed;
        public Light playerLight;
        void followLight()
        {
            if (playerLight != null)
            {
                speed = 1;
            }
            float walkspeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, walkspeed);            
        }
        void stopFollowing()
        {
            if (playerLight == null)
            {
                speed = 0;
            }
        }
        void Update()
        {
            followLight();
            stopFollowing();
        }
    }
