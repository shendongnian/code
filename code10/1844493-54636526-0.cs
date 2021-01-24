    public static void Main(string[] args)
    {
        int threads = Convert.ToInt32(File.ReadAllText(@"threads.txt"));
        var workItems = new List<object>();
        foreach (string user in File.ReadLines("x.txt"))
        {
            foreach (string pass in File.ReadLines("y.txt"))
            {
                foreach (string line in File.ReadLines("z.txt"))
                {
                    workItems.Add(new object[] { user, pass, line });
                }
            }
        }
        var opts = new ParallelOptions() { MaxDegreeOfParallelism = threads };
        var results = Parallel.ForEach(workItems, opts, DoWork);
        Console.WriteLine("Press ENTER to exit.");
        Console.Read();
    }
    private static void DoWork(object state)
    {
        //whatever 
    }
