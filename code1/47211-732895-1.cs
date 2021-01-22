    class Program
    {
    	static void Main()
    	{
    		// setup the metronome and make sure the EventHandler delegate is ready
    		Metronome metronome = new Metronome();
    
    		// wires up the metronome_Tick method to the EventHandler delegate
    		Listener listener = new Listener(metronome);
    		ListenerB listenerB = new ListenerB(metronome);
    		metronome.Go();
    	}
    }
    
    public class Metronome
    {
    	// a delegate
    	// so every time Tick is called, the runtime calls another method
    	// in this case Listener.metronome_Tick and ListenerB.metronome_Tick
    	public event EventHandler Tick;
    
    	// virtual so can override default behaviour in inherited classes easily
    	protected virtual void OnTick(EventArgs e)
    	{
    		// null guard so if there are no listeners attached it wont throw an exception
    		if (Tick != null)
    			Tick(this, e);
    	}
    
    	public void Go()
    	{
    		while (true)
    		{
    			Thread.Sleep(2000);
    			// because using EventHandler delegate, need to include the sending object and eventargs 
    			// although we are not using them
    			OnTick(EventArgs.Empty);
    		}
    	}
    }
    
    
    public class Listener
    {
    	public Listener(Metronome metronome)
    	{
    		metronome.Tick += new EventHandler(metronome_Tick);
    	}
    	
    	private void metronome_Tick(object sender, EventArgs e)
    	{
    		Console.WriteLine("Heard it");
    	}
    }
    
    public class ListenerB
    {
    	public ListenerB(Metronome metronome)
    	{
    		metronome.Tick += new EventHandler(metronome_Tick);
    	}
    	
    	private void metronome_Tick(object sender, EventArgs e)
    	{
    		Console.WriteLine("ListenerB: Heard it");
    	}
    }	
