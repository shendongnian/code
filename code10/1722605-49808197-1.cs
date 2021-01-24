    public interface In1
    {
    	int MyProperty
    	{
    		get;
    	}
    
    	bool Check
    	{
    		get;
    	}
    }
    
    class TestProp : In1
    {
    	public int MyProperty => Check ? 1 : 0;
    
    	public bool Check => true;
    }
