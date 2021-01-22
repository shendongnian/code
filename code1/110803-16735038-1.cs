try
{
	try
	{
		// get non-public constructor
		var cstor = typeof(ThreadAbortException)
			.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
		// create ThreadAbortException instance
		ThreadAbortException ex = cstor.Invoke(null) as ThreadAbortException;
		// throw..
		throw ex;
	}
	catch (ThreadAbortException)
	{
		Console.WriteLine("First");
	} 
}
catch (ThreadAbortException)
{
	Console.WriteLine("Second");
	Thread.ResetAbort();
} 
