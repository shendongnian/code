    public class MyClass
    {
    
    #region Constructors 
    	public MyClass(string directory)
    	{
    		this.Directory = directory;
    	}
    
    #endregion
    
    #region Properties
    
    	public MyClassState State {get;private set;}
    
    	private string _directory;
    
    	public string Directory 
    	{
    		get { return _directory;} 
    		private set 
    		{
    			_directory = value; 
    			if (string.IsNullOrEmpty(value)) 
    				this.State = MyClassState.Unknown; 
    			else 
    				this.State = MyClassState.Initialized;
    		}
    	}
    
    #endregion
    
    
    
    	public void LoadFromDirectory()
    	{
    		if (this.State != MyClassState.Initialized || this.State != MyClassState.Loaded)
    			throw new InvalidStateException();
    
    		// Do loading
    
    		this.State = MyClassState.Loaded;
    	}
    
    }
    
    public class InvalidStateException : Exception {}
    
    
    public enum MyClassState
    {
    	Unknown,
    	Initialized,
    	Loaded
    }
