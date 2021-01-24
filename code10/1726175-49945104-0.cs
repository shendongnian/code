    void Main()
    {
    	foreach (Process p in Process.GetProcesses())
    	{
    		Console.WriteLine($"Id:{p.Id},Process: {p.ProcessName}");
    	}
    }
