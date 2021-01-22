    static void restartApp() {
    	string commandLineArgs = getCommandLineArgs();
    	string exePath = Application.ExecutablePath;
    	try {
    		Application.Exit();
    		wait_allowingEvents( 1000 );
    	} catch( ArgumentException ex ) {
    		throw;
    	}
    	Process.Start( exePath, commandLineArgs );
    }
    static string getCommandLineArgs() {
    	Queue<string> args = new Queue<string>( Environment.GetCommandLineArgs() );
    	args.Dequeue(); // args[0] is always exe path/filename
    	return string.Join( " ", args.ToArray() );
    }
    static void wait_allowingEvents( int durationMS ) {
    	DateTime start = DateTime.Now;
    	do {
    		Application.DoEvents();
    	} while( start.Subtract( DateTime.Now ).TotalMilliseconds > durationMS );
    }
