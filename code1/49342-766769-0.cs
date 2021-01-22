    static void Main(string[] args)
    {
        // Approved processes.
        List<string> approvedProcesses = new List<string>();
        approvedProcesses.Add("chrome");
        approvedProcesses.Add("svchost");
        // LINQ query for processes that match your approved processes.
        var processes = from p in System.Diagnostics.Process.GetProcesses()
                        where approvedProcesses.Contains(p.ProcessName)
                        select p;
        // Output matching processes to console.
        foreach (var process in processes)
            Console.WriteLine(process.ProcessName + " " + process.Id.ToString());
        Console.ReadLine();
    }
