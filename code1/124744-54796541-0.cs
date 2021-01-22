    public class SysManager
    {
    	private static readonly SysManager_instance = new SysManager();
    
    	static SysManager() {}
    
    	private SysManager(){}
    
    	public static SysManager Instance
    	{
    		get {return _instance;}
    	}
    }
