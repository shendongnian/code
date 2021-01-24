    public class Ball : MonoBehaviour
    {
    
        ScoreSys scoreSys;
        Rigidbody rb;
        public float destroyTimeOut = 2;
        bool hitBase = false;
        void Start()
        {
            GameObject scoreObj = GameObject.Find("ScoreSystem");
            scoreSys = scoreObj.GetComponent<ScoreSys>();
    
            rb = GetComponent<Rigidbody>();
        }
    
    
        void Update()
        {
            if (rb.position.y < -3)
            {
                scoreSys.Count--;
                Destroy(gameObject);
            }
    
            if (hitBase)
            {
                timer += Time.deltaTime;
                if (timer > destroyTimeOut)
                {
                    scoreSys.Count--;
                    Destroy(gameObject);
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
    }
