    	static void LongRunningOperation(CancellationToken token)
    	{
    		TaskCompletionSource<int> tcs1 = new TaskCompletionSource<int>();
    		token.Register(() => { tcs1.TrySetCanceled(token); });
    		Task.Run(() =>
    		{
    			// long running operation here
    			Thread.Sleep(10000);
    			tcs1.TrySetResult(0);
    		}, token);
    		tcs1.Task.Wait();
    	}
