    public class healthScript : MonoBehaviour
    {
       //Variable declaration
	   private int _health;
	   // Use this for initialization
	   void Start()
	   {
	    	_health = 100;
	   }
        // Update is called once per frame
	    void Update () {
		    Debug.Log(_health);
	    }
    }
