    static void Main(string[] args)
    {
    	Trace.Listeners.Clear();
    
    	TextWriterTraceListener twtl = new TextWriterTraceListener(Path.Combine(Path.GetTempPath(), AppDomain.CurrentDomain.FriendlyName));
    	twtl.Name = "TextLogger";
    	twtl.TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.DateTime;
    
    	ConsoleTraceListener ctl = new ConsoleTraceListener(false);
    	ctl.TraceOutputOptions = TraceOptions.DateTime;
    
    	Trace.Listeners.Add(twtl);
    	Trace.Listeners.Add(ctl);
    
    	Trace.WriteLine("The first line to be in the logfile and on the console.");
    }
