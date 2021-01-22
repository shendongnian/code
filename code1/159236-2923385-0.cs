    static void Main(string[] args)
    {
        WaitCallback del = state =>
        {
            ManualResetEvent[] resetEvents = new ManualResetEvent[10];
            WebClient[] clients = new WebClient[10];
            Console.WriteLine("Starting requests");
            for (int index = 0; index < 10; index++)
            {
                resetEvents[index] = new ManualResetEvent(false);
                clients[index] = new WebClient();
                clients[index].OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
                clients[index].OpenReadAsync(new Uri(@"http:\\www.google.com"), resetEvents[index]);
            }
            
            bool succeeded = ManualResetEvent.WaitAll(resetEvents, 10000);
            Complete(succeeded);
            for (int index = 0; index < 10; index++)
            {
                resetEvents[index].Dispose();
                clients[index].Dispose();
            }
        };
        ThreadPool.QueueUserWorkItem(del);
        Console.WriteLine("Waiting...");
        Console.ReadKey();
    }
    static void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        // Do something with data...Then close the stream
        e.Result.Close();
        ManualResetEvent readCompletedEvent = (ManualResetEvent)e.UserState;
        readCompletedEvent.Set();
        Console.WriteLine("Received callback");
    }
    
    static void Complete(bool succeeded)
    {
        if (succeeded)
        {
            Console.WriteLine("Yeah!");
        }
        else
        {
            Console.WriteLine("Boohoo!");
        }
    }
