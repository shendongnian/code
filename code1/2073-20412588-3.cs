    public class SingleInstanceApp
    {
    	[STAThread]
    	public static void Main(string[] args)
    	{
    		Mutex _mutexSingleInstance = new Mutex(true, "MonitorMeSingleInstance");
    
    		if (_mutexSingleInstance.WaitOne(TimeSpan.Zero, true))
    		{
    			try
    			{
    				var app = new App();
    				app.Run([new YourMainWindow]);
    			}
    			finally
    			{
    				_mutexSingleInstance.ReleaseMutex();
    				_mutexSingleInstance.Close();
    			}
    		}
    		else
    		{
    			MessageBox.Show("One instance is already running.");
    
    			var processes = Process.GetProcessesByName(Assembly.GetEntryAssembly().GetName().Name);
    			{
    				if (processes.Length > 1)
    				{
    					foreach (var process in processes)
    					{
    						if (process.Id != Process.GetCurrentProcess().Id)
    						{
    							WindowHelper.SetForegroundWindow(process.MainWindowHandle);
    						}
    					}
    				}
    			}
    		}
    	}
    }
