    public class ExcutedContext
    {
    	public ExcutedContext(IMethodReturnMessage returnMethod)
    	{
    		Args = returnMethod.Args;
    		MethodName = returnMethod.MethodName;
    		Result = returnMethod.ReturnValue;
    	}
    
    	public object[] Args { get; set; }
    
    	public string MethodName { get; set; }
    
    	public object Result { get; set; }
    }
    
    /// <summary>
    /// Filter AttributeBase
    /// </summary>
    public abstract class AopBaseAttribute : Attribute, IExcuteFilter
    {
    
    	public virtual void OnExcuted(ExcutedContext context)
    	{
    	}
    
    	public virtual void OnExcuting(ExcuteingContext context)
    	{
    	}
    }
    
    /// <summary>
    /// Customer Filter
    /// </summary>
    public class AuthorizedUserDataAttribute : AopBaseAttribute
    {
    	public override void OnExcuting(ExcuteingContext context)
    	{
    		//Console.WriteLine("Test");
    		//Implement validation here
    	}
    }
