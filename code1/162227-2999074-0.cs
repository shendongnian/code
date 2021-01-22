    public abstract class BaseFunctionality
    {
    	public abstract string methodName(int id, string parameter);
    
    	protected ThingClass createThing(int id, string parameter)
    	{
    		// instantiate and return result
    	}
    
    	protected bool isValidId(int id)
    	{
    		// evaluate validity of id
    	}
    }
    
    public class Admin : BaseFunctionality
    {
    	public override string methodName(int id, string parameter)
    	{
    		if(!isValidId(id)) return string.Empty;
    		var thing = createThing(id, parameter);
    		thing.Execute();
    	}
    }
    
    public class Front : BaseFunctionality
    {
    	public override string methodName(int id, string parameter)
    	{
    		if(!isValidId(id)) return null;
    		Console.WriteLine(parameter);
    	}
    }
