    public class TestClass
    {
    	private Vector3 _v = 0;
    	public Vector3 V { get { return _v; } set { _v = value; } }
    
    	void DoSomething ()
    	{
    		V = new Vector3 (2, 0, 0); // This will trigger 'set'.
    		V.x = 2;                   // This will not.
    	}
    }
