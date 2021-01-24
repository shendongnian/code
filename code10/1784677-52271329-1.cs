    public static IWebDriver driver; //Init Driver Interface
    public static int BulkListCount = 50; //Replace the value with your own count.
    /// <summary>
    /// Starts looping through Ticket building tasks.
    /// </summary>
    /// <param name="startRow">Indicates what row to start at.</param>
    /// <param name="numTasks">Indicates how many tasks can run at once.</param>
    public static void ThreadStart(int startRow, int numTasks)
    {
        SemaphoreSlim semaphore = new SemaphoreSlim(numTasks);  //Allows for multiple instances of Task to be run.
        for (int i = startRow; i < BulkListCount; i++)   //Starts a loop to go through each site in the SiteList starting at i
        {
            semaphore.Wait(); //Conditional stopping point set by Semaphore.
            Task.Run(() =>
            {
                //Any method you want to run
                Task_Bulk(driver, names);
            })
            .ContinueWith(_ => semaphore.Release()); //Releases the session when finished
         }
    }
    [STAThread]
    private static void Task_Bulk(IWebDriver driver, string names)
    {
        TimeSpan timespan = TimeSpan.FromMinutes(4);
        //List out your chrome options here and replace new ChromeOptions() with your own
        using (driver = new ChromeDriver(driverService, new ChromeOptions(), timespan))
        {
            // Do stuff here
        }
    }
    public static void Main(string[] args)
    {
        ThreadStart(0,2); //Will start the method at row 0 with 2 browsers
    }
    
