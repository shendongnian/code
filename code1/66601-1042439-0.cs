    var resetEvent = new ManualResetEvent(false);
    ThreadPool.QueueUserWorkItem(state =>
    				{
    					Thread.Sleep(5000);//LongRunning task, async call
    					resetEvent.Set();
    				});
    resetEvent.WaitOne();// blocking call, when user clicks OK 
