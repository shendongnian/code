    public class Watcher : IWatcher
    {
    	private readonly string _path;
    	private readonly bool _deletionPolicy;
    
    	public Watcher(string path, bool deletionPolicy = false)
    	{
    		_path = path;
    		_deletionPolicy = deletionPolicy;
    	}
    }
