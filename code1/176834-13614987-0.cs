    using System;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    static int Main()
    {
    	Application.Run(new MyApplicationContext());
    	return 0;
    }
    
    public class MyApplicationContext : ApplicationContext
    {
    	private SynchronizationContext _mainThreadMessageQueue = null;
    	private Stream _stdInput;
    
    	public MyApplicationContext()
    	{
    		_stdInput = Console.OpenStandardInput();
    		// feel free to use a better way to post to the message loop from here if you know one ;)    
    		System.Windows.Forms.Timer handoffToMessageLoopTimer = new System.Windows.Forms.Timer();
    		handoffToMessageLoopTimer.Interval = 1;
    		handoffToMessageLoopTimer.Tick += new EventHandler((obj, eArgs) => { PostMessageLoopInitialization(handoffToMessageLoopTimer); });
    		handoffToMessageLoopTimer.Start();
    	}
    	
    	private void PostMessageLoopInitialization(System.Windows.Forms.Timer t)
    	{
    		if (_mainThreadMessageQueue == null)
    		{
    			t.Stop();
    			_mainThreadMessageQueue = SynchronizationContext.Current;
    		}
    
    		// constantly monitor standard input on a background thread that will
    		// signal the main thread when stuff happens.
    		BeginMonitoringStdIn(null);
    		// start up your application's real work here
    	}
    	
    	private void BeginMonitoringStdIn(object state)
    	{
    		if (SynchronizationContext.Current == _mainThreadMessageQueue)
    		{
    			// we're already running on the main thread - proceed.
    			var buffer = new byte[128];
    
    			_stdInput.BeginRead(buffer, 0, buffer.Length, (asyncResult) =>
    				{
    					int amtRead = _stdInput.EndRead(asyncResult);
    
    					if (amtRead == 0)
    					{
    						_mainThreadMessageQueue.Post(new SendOrPostCallback(ApplicationTeardown), null);
    					}
    					else
    					{
    						BeginMonitoringStdIn(null);
    					}
    				}, null);
    		}
    		else
    		{
    			// not invoked from the main thread - dispatch another call to this method on the main thread and return
    			_mainThreadMessageQueue.Post(new SendOrPostCallback(BeginMonitoringStdIn), null);
    		}
    	}
    	
    	private void ApplicationTeardown(object state)
    	{
    		// tear down your application gracefully here
    		_stdInput.Close();
    
    		this.ExitThread();
    	}
    }
