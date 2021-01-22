    abstract class ClassBase
    {
    	public abstract String Test { get; protected set; }
    }
    
    class ClassDerive : ClassBase
    {
    	string _s;
    
    	public override String Test
    	{
    		get { return _s; }
    		protected set { _s = value; }
    	}
    
    	public void SetTest(String test)
    	{
    		this.Test = test;
    	}
    }
