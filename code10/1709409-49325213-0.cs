    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float tilt;
        public Boundary boundary;
        private Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
    
        public GameObject shot;
        public Transform shotSpawn;
        public float fireRate;
        private float nextFire;
        void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
    
       void FixedUpdate() //no longer has private keyword appended to method
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
    
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = movement * speed;
    
            rb.position = new Vector3
                (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
                );
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        }
    
    
    }
