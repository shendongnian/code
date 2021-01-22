    using System;
    using System.Threading;
    
    class Program
    {
    	AutoResetEvent _autoEvent;
    	
    	static void Main()
    	{
    		Program p = new Program();
    		p.RunWidget();
    	}
    	
    	public Program()
    	{
    		_autoEvent = new AutoResetEvent(false);
    	}
    	
    	public void RunWidget()
    	{
    		ThirdParty widget = new ThirdParty();			
    		widget.Completed += new EventHandler(this.Widget_Completed);
    		widget.DoWork();
    		
    		// Waits for signal that work is done
    		_autoEvent.WaitOne();
    	}
    	
    	// Assumes that some kind of args are passed by the event
    	public void Widget_Completed(object sender, EventArgs e)
    	{
    		_autoEvent.Set();
    	}
    }
