    public static List<string> MyList { get; set; }
    public static object LockObject { get; set; }
    
    static void Main(string[] args)
    {
        Console.Clear();
    
        Program.LockObject = new object();
    
        // Create the list
        Program.MyList = new List<string>();
    
        // Add 100 items to it
        for (int i = 0; i < 100; i++)
        {
            Program.MyList.Add(string.Format("Item Number = {0}", i));
        }
    
        // Start Threads
        for (int i = 0; i < 5; i++)
        {
            Thread thread = new Thread(new ThreadStart(Program.PopItemFromStackAndPrint));
    
            thread.Name = string.Format("Thread # {0}", i);
    
            thread.Start();
        }
    } 
    
    
    public static void PopItemFromStackAndPrint()
    {
        if (Program.MyList.Count == 0)
        {
            return;
        }
    
        string item = string.Empty;
    
        lock (Program.LockObject)
        {
            // Get first Item
            item = Program.MyList[0];
    
            Program.MyList.RemoveAt(0);
        }
    
        Console.WriteLine("{0}:{1}", System.Threading.Thread.CurrentThread.Name, item);
    
        // Sleep to show other processing for examples only
        System.Threading.Thread.Sleep(10);
    
        Program.PopItemFromStackAndPrint();
    }
