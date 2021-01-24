    public class MyInterceptionBehavior : IInterceptionBehavior
    {
    	public bool WillExecute
    	{
    		get { return true; }
    	}
    
    	public IEnumerable<Type> GetRequiredInterfaces()
    	{
    		return Enumerable.Empty<Type>();
    	}
    
    	public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
    	{
    		IMethodReturn result = getNext()(input, getNext);
    		Console.WriteLine("Interception Called");
    		return result;
    	}
    
    }
