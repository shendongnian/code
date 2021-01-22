try
{
	try
	{
		Thread.CurrentThread.Abort();
	}
	catch (ThreadAbortException)
	{
		Console.WriteLine("First");
		//Try to swallow it.
	} //CLR automatically reraises the exception here .
}
catch (ThreadAbortException)
{
	Console.WriteLine("Second");
	Thread.ResetAbort();
	//Try to swallow it again .
} //The in - flight abort was reset , so it is not reraised again .
