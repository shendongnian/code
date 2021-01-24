    private static System.Timers.Timer aTimer;
    public static void Main()
    {
        SetTimer(); //MyFirstTask starts running over and over in another thread
        Task.Run(() => MySecondTask());
    }
    private static void SetTimer()
    {
        // Create a timer with a 1ms interval (has to be > 0)
        aTimer = new System.Timers.Timer(1);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += MyFirstTask;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }
    private static async void MyFirstTask(Object source, ElapsedEventArgs e)
    {
       // do stuff
       await FirstTaskImplementation();
       // cleanup
    }
    
    private async Task MySecondTask()
    {
       // do stuff
       await SecondTaskImplementation();
       // cleanup
    }
