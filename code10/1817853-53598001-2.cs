    public class MiddleConfig
    {
    	private readonly ICollection<string> _c;
    
    	public MiddleConfig()
    	{
    		_c = new Collection<string>();
    	}
    
    	public void AddPath(string path)
    	{
    		_c.Add(path);
    	}
    
    	public IEnumerable<string> Paths => _c;
    }
