     public class headLights : MonoBehaviour {
    
        public Light frontLight;
        public Light backLight;
    
    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
    	    if(frontLight != null) {
            	frontLight.enabled = !frontLight.enabled;
    	    }
        }
    
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(backLight != null) {
            	backLight.enabled = !backLight.enabled;
    	    }
        }
    }
