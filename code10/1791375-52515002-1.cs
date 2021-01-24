    class Program
    {
    	    public delegate void ClosedEventHandler(object sender, Func<Exception, Task> e);
            public ClosedEventHandler Closed { get; set; }    
            static void Main(string[] args)
            {
                Program hub = new Program();
                hub.Closed = hub.SomethingToDoWhenClosed;    
                Observable
                    .FromEventPattern<ClosedEventHandler, Func<Exception, Task>>(
                        h => hub.Closed += h,
                        h => hub.Closed -= h)
                    .Subscribe(x =>
                    {
                        // this is hit
                    });    
                hub.Closed(hub, e => null);
            }
    
            public void SomethingToDoWhenClosed(object sender, Func<Exception, Task> e)
            {
            }
	}
