    void Main()
    {
    	Console.WriteLine( "main thread started" );
    
    	var workerClass = new WorkerClassWithEvent();
    	workerClass.PerformWork();
    	
    	var waiter = new EventWaiter( workerClass, "WorkCompletedEvent" );
    	waiter.WaitForEvent( TimeSpan.FromSeconds( 10 ) );
    	
    	Console.WriteLine( "main thread continues after waiting" );
    }
    
    public class WorkerClassWithEvent
    {
    	public void PerformWork()
    	{
    		var worker = new BackgroundWorker();
    		worker.DoWork += ( s, e ) =>
    		{
    			Console.WriteLine( "threaded work started" );
    			Thread.Sleep( 1000 ); // <= the work
    			Console.WriteLine( "threaded work complete" );
    		};
    		worker.RunWorkerCompleted += ( s, e ) =>
    		{
    			FireWorkCompletedEvent();
    			Console.WriteLine( "work complete event fired" );
    		};
    
    		worker.RunWorkerAsync();
    	}
    
    	public event Action WorkCompletedEvent;
    	private void FireWorkCompletedEvent()
    	{
    		if ( WorkCompletedEvent != null ) WorkCompletedEvent();
    	}
    }
    
    public class EventWaiter
    {
    	private AutoResetEvent _autoResetEvent = new AutoResetEvent( false );
    	private EventInfo _event 			   = null;
    	private object _eventContainer 		   = null;
    
    	public EventWaiter( object eventContainer, string eventName )
    	{
    		_eventContainer = eventContainer;
    		_event = eventContainer.GetType().GetEvent( eventName );
    	}
    
    	public void WaitForEvent( TimeSpan timeout )
    	{
    		_event.AddEventHandler( _eventContainer, (Action)delegate { _autoResetEvent.Set(); } );
    		_autoResetEvent.WaitOne( timeout );
    	}
    }
