    public class Global : HttpApplication
    {
    	private static Timer timer;
    	private int interval = 60000*5; // five minutes
    
    
    	protected void Application_Start(object sender, EventArgs e)
    	{
    		if (timer == null)
    		{
    			timer = new Timer(new TimerCallback(ScheduledWorkCallback), HttpContext.Current, interval, interval);
    			ScheduledWorkCallback(HttpContext.Current);
    		}
    	}
    
    
    	public static void ScheduledWorkCallback(object sender)
    	{
    		//do your work here
    	}
    }
