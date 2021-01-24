    public static Timer YourTimer;
    
    static void Main(string[] args)
    {
        YourTimer = new System.Timers.Timer(1000); //In milliseconds
        YourTimer.Elapsed += new ElapsedEventHandler(RunThis);
        YourTimer.AutoReset = true;
        YourTimer.Enabled = true;
    }
    private static void RunThis(object source, ElapsedEventArgs e)
    {
        //Your API call here
    }
