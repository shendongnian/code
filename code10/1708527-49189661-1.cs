    [PSerializable]
	public class PrintExceptionAttribute : OnExceptionAspect
	{
	    public override void OnException(MethodExecutionArgs args)
	    {
	        Console.WriteLine(args.Exception.Message); // This is whatever you want to handle the exception
	    }
	}
