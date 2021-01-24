    public class Moving : MonoBehaviour {
    
        public Vector3 offset;
        public float offsetTime = 2.0f;
        private float t = 0.0f;
        private bool moveMe = false;
        private Vector3 targetPos;
        private Vector3 startPos;
    
    	// Use this for initialization
    	void Start () {
            targetPos = transform.position + offset;
            startPos = transform.position;
            StopMoving();
        }
    
        public void StartMoving()
        {
            t = 0.0f;
            moveMe = true;
        }
    
        private void StopMoving()
        {
            t = 0.0f;
            moveMe = false;
        }
    	
    	// Update is called once per frame
    	void Update () {
    
            if (moveMe)
            {
                t += Time.deltaTime / offsetTime;
    
                if(t < 1.0f)
                {
                    transform.position = Vector3.Slerp(startPos, targetPos, t);
                }
                else
                {
                    StopMoving();
                }
            }
    	}
    }
