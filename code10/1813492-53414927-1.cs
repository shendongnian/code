    public class SwipeControl : MonoBehaviour {
	    public Transform cylinder;
	    private float sensitivity = 10f;
	
	    void Update()
	    {
		    if (Input.GetMouseButton(0))
		    {
			    float xAxis = Input.GetAxis("Mouse X");
			    cylinder.Rotate(0, xAxis * sensitivity * Time.deltaTime, 0);
		    }
	    }
    }
