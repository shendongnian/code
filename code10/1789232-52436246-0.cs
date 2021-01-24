    static async Task RunJob(string parms)
    {
        //Console.WriteLine("PARMS: {0}", parms);
        Process proc = new Process();
        ProcessStartInfo start = new ProcessStartInfo();
        start.WindowStyle = ProcessWindowStyle.Normal;
        start.FileName = @"C:\program.exe";
        string parameters = String.Format(parms.ToString());
        start.Arguments = parameters;
        start.UseShellExecute = true;
        proc.StartInfo = start;
        proc.Start();
        proc.WaitForExit();
    }
