    public class Ball : MonoBehaviour {
    
        private static int Count;
        public Text TextCount;
    
        // Update is called once per frame
        Rigidbody rb;
        public float destroyTimeOut = 2;
        bool hitBase = false;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            Count = 82;
            SetTextCount();
        }
    
    
        void Update () {
            if(rb.position.y < -3)
            {
                Destroy(gameObject);
                Count = Count - 1;
                SetTextCount();
    
            }
            if (hitBase)
            {
                timer += Time.deltaTime;
                if (timer > destroyTimeOut)
                {
                    Destroy(gameObject);
                    Count = Count - 1;
                    SetTextCount();
    
                }
            }
        }
        float timer;
        private void OnCollisionEnter(Collision collision)
        {
    
            if (collision.gameObject.CompareTag("base"))
            {
                hitBase = true;
            }
        }
    
        void SetTextCount()
        {
            TextCount.text = Count.ToString();
        }
    
    }
