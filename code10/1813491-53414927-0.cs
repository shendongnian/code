    public class SwipeControl : MonoBehaviour {
	public Transform cylinder;
	
	    void Update()
	    {
		    if (Input.GetMouseButton(0))
		    {
			    cylinder.transform.Rotate(0f, 0f, Input.mousePosition.x);
	 	    }
	    }
    }
