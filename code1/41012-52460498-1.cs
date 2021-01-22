    static void Main(string[] args)
    {
        Process.GetProcesses().ToList().ForEach(p =>
        {
            Console.WriteLine(
                p.ProcessName + " p.Threads.Count=" + p.Threads.Count + " Id=" + p.Id);
        });
        Console.ReadKey();
    }
