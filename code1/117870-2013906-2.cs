    public class Foo
    {
    	public EventHandler SomeEvent;
    	
    	public void Bar()
    	{
    		if (SomeEvent != null)
    		{
    			SomeEvent(this, EventArgs.Empty);
    		}
    	}
    }
