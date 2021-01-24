	public class OperationResult
	{
	    public bool Successful { get; protected set; }
	    public string FailureMessage { get; protected set; }
	    public Exception Exception { get; protected set; }
	
	    protected OperationResult() { }
	
	    public static OperationResult Success()
	    {
	        Console.WriteLine(1);
	        return new OperationResult() { Successful = true };
	    }
	
	    public static OperationResult<T> Success<T>(T result)
	    {
	        Console.WriteLine(2);
	        return new OperationResult<T>(result) { Successful = true };
	    }
	}
	
	public class OperationResult<T> : OperationResult
	{
		internal OperationResult(T result) { Result = result; }
		
	    public T Result { get; private set; }
	}
