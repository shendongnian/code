	static void Main(string[] args)
	{
		var processes = GetProcesses(new[] { "name1", "name2", "explorer"});
	}
	public static IList<Process> GetProcesses(string[] processNames)
	{
		var processes = new List<Process>(processNames.Length);
		foreach (var processName in processNames)
		{
			var namedProcesses = Process.GetProcessesByName(processName);
			processes.AddRange(namedProcesses);
		}
		return processes;
	}
