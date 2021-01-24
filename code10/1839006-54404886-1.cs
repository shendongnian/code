    public class healthScript : MonoBehaviour
    {
	    //Property
	    public int Health
	    {
		    get { return _health; }
		    set
		    {
			    _health = value;
			    Debug.Log("Health changed to value: " + _health);
		    }
	    }
	    //Variable declaration
	    private int _health = 100;
    }
