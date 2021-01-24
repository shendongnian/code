	if (token.IsCancellationRequested)
	{
		Console.WriteLine("Cancellation Token Detected");
		break;
	}
	token.WaitHandle.WaitOne(1000);
