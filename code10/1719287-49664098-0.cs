    private static bool keepRunning = true;
    
    public static void Main(string[] args)
    {
       Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e) {
             e.Cancel = true;
             keepRunning = false;
          };
    
       while (keepRunning) 
       {
          // Do stuff
       }
       Console.WriteLine("exited gracefully");
    }
        
