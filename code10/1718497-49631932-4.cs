    public class ExcuteingContext 
    {
    	public ExcuteingContext(IMethodCallMessage callMessage)
    	{
    		Args = callMessage.Args;
    		MethodName = callMessage.MethodName;
    	}
    
    	public object[] Args { get; set; }
    
    	public string MethodName { get; set; }
    
    	public object Result { get; set; }
    }
    
