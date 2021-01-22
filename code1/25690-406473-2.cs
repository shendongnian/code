    static class Program
    {
    	[STAThread]
    	static void Main(string[] argv)
    	{
    		try
    		{
    			AppDomain.CurrentDomain.UnhandledException += (sender,e)
                    => FatalExceptionHandler.Handle((Exception)e.ExceptionObject);
    			Application.ThreadException += (sender,e)
                    => FatalExceptionHandler.Handle(e.Exception);
    			// whatever you need/want here
    			Application.Run(new MainWindow());
    		}
    		catch (Exception huh)
    		{
    			FatalExceptionHandler.Handle(huh);
    		}
    	}
    }
