    public void Start()
    {
	   _cts = new CancellationTokenSource();
	   var token = _cts.Token;
	
      Task.Factory.StartNew(()=> {
         using(var pullSocket = new PullSocket("tcp://ip1:port1"))
         {
		    while (cancellationToken.IsCancellationRequested == false)
            {
				NetMQMessage message = new NetMQMessage();
				bool success = workerSocket.TryReceiveMultipartMessage(TimeSpan.FromSeconds(5), ref message);
				
				if (success == false)
				{
					continue;
				}
				
				//if You reach this line, than You have a message
			}
         }
        },
		token,
        TaskCreationOptions.LongRunning,
        TaskScheduler.Default);
    }
    public void Stop()
    {
        _cts.Cancel();
        _cts.Token.WaitHandle.WaitOne();//if You want wait until service will stop
    }
