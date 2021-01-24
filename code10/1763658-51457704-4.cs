    public class SomeClass
    {
    	public SomeClass()
    	{
    		DoSomething = this.DoSomething_Internal ;
    	}
    
    	public Action DoSomething { get; } 
    
    	private void DoSomething_Internal() { }
    }
