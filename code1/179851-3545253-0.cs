    Process p = /*get the desired process here*/;
    PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set", p.ProcessName);
	PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);
	while (true)
	{
		Thread.Sleep(500);
		double ram = ramCounter.NextValue();
		double cpu = cpuCounter.NextValue();
		Console.WriteLine("RAM: "+(ram/1024/1024)+" MB; CPU: "+(cpu)+" %");
	}
