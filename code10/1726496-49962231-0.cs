	public class OperationResult
	{
	    public bool Successful { get; protected set; }
	    public string FailureMessage { get; protected set; }
	    public Exception Exception { get; protected set; }
	
	    protected OperationResult() { }
	
	    public static OperationResult Success()
	    {
	        Console.WriteLine(1);
	        return new OperationResult()
	        {
	            Successful = true
	        };
	    }
		
	    public static OperationResult<T> Success<T>(T result)
	    {
	        return OperationResult<T>.Success(result);
	    }
	}
	
	public class OperationResult<T> : OperationResult
	{
	    public T Result { get; private set; }
	
	    private OperationResult () { }
	
	    public static OperationResult<T> Success(T result)
	    {
	        Console.WriteLine(2);
	        return new OperationResult<T>() { Successful = true, Result = result };
	    }
	}
