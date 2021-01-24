    Process p = Process.GetProcessById(21576); //provide the correct process Id
    if (p != null)
    {
        Console.WriteLine(p.MainModule.FileName); 
    }
