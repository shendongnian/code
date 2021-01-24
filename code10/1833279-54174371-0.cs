    public class cubeControls : MonoBehaviour
    {
        // Constants for object rotation
        public GAmeObject spherePrefab;
    
        // Update is called once per frame
        void Update()
        {
    		if (Input.GetKeyDown(KeyCode.X))
    		{
    			Instantiate(spherePrefab, transform.position, transform.rotation);
    		}
    	}
    }
