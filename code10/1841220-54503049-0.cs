    Timer myTimer = new Timer();
    myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
    myTimer.Interval = 1000; // 1000 ms is one second
    myTimer.Start();
    
    public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
    {
         System.Diagnostics.Process[] procs = 
             System.Diagnostics.Process.GetProcessesByName("notepad");
    
         //isButtonEnabled is needed to be defined on the upper context
         isButtonEnabled = procs.Count() != 0
              
    }
