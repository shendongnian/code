    internal class Waitress : CollisionTrigger
    {
    	public override void FakeOnTriggerStay()
    	{
    		// Replace this with input system you are using.
    		if(Input.GetKeyDown(...))
    		{
    			Debug.Log("Hi");
    		}
    	}
    }
