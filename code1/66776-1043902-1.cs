    abstract class ClassBase
    {
    	public abstract String Test { get; }
    }
    
    class ClassDerive : ClassBase
    {
    	string _s;
    
    	public override string Test
    	{
    		get { return _s; }
    	}
    
    	public void SetTest(String test)
    	{
    		this._s = test;
    	}
    }
