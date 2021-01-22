    public class PermitRepository
    {
    	private static PermitRepository instance = null;
    	private PermitRepository() {}
    	public static void setTestingInstance(PermitRepository newInstance)
    	{
    		instance = newInstance;
    	}
    	public static PermitRepository getInstance()
    	{
    		if (instance == null) 
    		{
    			instance = new PermitRepository();
    		}
    		return instance;
    	}
    	public Permit findAssociatedPermit(PermitNotice notice) 
    	{
    	...
    	}
    ...
    }
