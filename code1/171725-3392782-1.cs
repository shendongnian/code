    ConcurrentQueue<TimeSpan> _queue;
    public override void OnInvoke(MethodInterceptionArgs args)
    {
    	var startDtg = DateTime.Now;
    	args.Proceed();
    	var duration = DateTime.Now - startDtg;
    	Task.Factory.StartNew(() => _queue.Add(duration)); 
    }
