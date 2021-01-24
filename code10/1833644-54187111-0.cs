    public class Float : MonoBehaviour 
    {
        Text text;
        public float fadeDuration = 2.0f;
        public float speed = 2.0f;
    
        // Use this for initialization
        void Start ()
        {
            text = this.GetComponent<Text>();
            // Hide object
            gameObject.SetActive(false);
        }
    
        public ShowTextAndFade(Vector3 initialPosition)
        {
            StartCoroutine (Fade(initialPosition));
        }
    
        private IEnumerator Fade (Vector3 initialPosition)
        {
            // Show object
            gameObject.SetActive(true);
    
            // Set position
            transform.position = initialPosition;
    
            float fadespeed = (float)1.0 / fadeDuration;
            Color c = text.color;
    
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * fadespeed)
            {
                c.a = Mathf.Lerp(1, 0, t);
                text.color = c;
                yield return true;
            }
    
            Destroy(this.gameObject);
        }
    
        // Update is called once per frame
        void Update ()
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * speed);  
        }
    }
