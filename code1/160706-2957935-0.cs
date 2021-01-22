    public delegate void AddEntryDelegate(string entry, bool error);
    
    public static Form mainwin;
    
    public static event AddEntryDelegate OnNewLogEntry;
    
    public static void AddEntry(string entry) {
      ThreadSafeAddEntry( entry, false );
    }
    
    private static void ThreadSafeAddEntry (string entry, bool error)
        {
        try
            {
            if (mainwin != null && mainwin.InvokeRequired)  // we are in a different thread to the main window
                mainwin.Invoke (new AddEntryDelegate (ThreadSafeAddEntry), new object [] { entry, error });  // call self from main thread
            else
                OnNewLogEntry (entry, error);
            }
        catch { }
        }
    
    public static AddEntryDelegate WriteToFile(string filename, string appName) {
        //Do your WriteToFile work here
        }
    }
