     void Main()
    {
    	List<RailwayUser> railwayUsers = new List<RailwayUser>();
    	
    	railwayUsers.Add(new RailwayUser());
    	railwayUsers.Add(new RailwayUser());
    
    	RailwayUser.TestNotification();
    }
    
    public enum Colour
    {
    	Red,
    	Green,
    	NoSignal
    }
    
    public class RailwaySignal
    {
    	private string RailwaySignalName {get; set;}
    	
    	public string Name => RailwaySignalName;
    	
    	public RailwaySignal()
    	{
    		
    	}
    	
    	public RailwaySignal(string railwaySignalName)
    	{
    		RailwaySignalName = railwaySignalName;
    	}	
    	
    	// Delegate for handling event
    	public delegate void RailwaySignalEventHandler(object source, Colour e);
    
    	// Delagate object for handling event
    	private RailwaySignalEventHandler _railwaySignalEvent;
    
    	// Event Accessor
    	public event RailwaySignalEventHandler RailwaySignalEvent
    	{
    		add
    		{
    			lock (this)
    			{
    				_railwaySignalEvent += value;
    			}
    		}
    
    		remove
    		{
    			lock (this)
    			{
    				_railwaySignalEvent -= value;
    			}
    		}
    	}
    
    	// Invoke Event for subscribed clients
    	private void Notify()
    	{
    		if (_railwaySignalEvent != null)
    			_railwaySignalEvent.Invoke(this, Colour.Green);
    	}
    
    	// Test the Event Invocation
    	public void TestEvent()
    	{
    		Notify();
    	}
    }
    
    public class RailwayUser
    {
    	private static RailwaySignal railwaySignal { get; set;} = new RailwaySignal("Signal1");
    	
    	public RailwayUser()
    	{
    		railwaySignal.RailwaySignalEvent += this.Notice;		
    	}
    	
    	public static void TestNotification()
    	{
    		railwaySignal.TestEvent();
    	}
    	
    	public void Notice(object sender, Colour color)
    	{		
    		Console.WriteLine($"Notice Called, Colour is :: {color}, Sender is :: {((RailwaySignal)sender).Name}");
    	}
    }
