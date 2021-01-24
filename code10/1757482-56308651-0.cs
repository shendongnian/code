	using System.Diagnostics;
	using System.Linq;
	public IntPtr GetModuleBaseAddress(string processName, string moduleName)
	{
		// Get an instance of the specified process
		Process process;
		try
		{
			process = Process.GetProcessesByName(processName)[0];
		}
		catch (IndexOutOfRangeException)
		{
			// The process isn't currently running
			throw new ArgumentException($"No process with name {processName} is currently running");
		}
		// Get an instance of the specified module in the process
		// We use linq here to avoid unnecesary for loops
		var module = process.Modules.Cast<ProcessModule>().SingleOrDefault(m => string.Equals(m.ModuleName, moduleName, StringComparison.OrdinalIgnoreCase));
		//Return IntPtr.Zero if the module doesn't exist in the process
		return module?.BaseAddress ?? IntPtr.Zero;
	}
	var modBaseAddress = GetModuleBaseAddress("Tutorial-x86_64.exe", "Tutorial-x86_64.exe");
