    public class YourForm
    {
    	private static object syncObject = new object();
    	
    	public void Moderate()
    	{
    		lock(syncObject)
    		{
    			// do your business
    		}
    	}
    }
