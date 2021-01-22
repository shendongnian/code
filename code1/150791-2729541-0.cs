    static void Main(string[] args)
    {
        Process p = new Process();
        p.StartInfo.FileName = "shutdown";
        p.StartInfo.Arguments = "/r";
        p.Start();
        Thread.Sleep(5000);
        p.StartInfo.Arguments = "/a";
        p.Start();
    
    }
