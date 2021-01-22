	[DllImport("kernel32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);
	
	static void Main()
	{
		long memKb;
		GetPhysicallyInstalledSystemMemory(out memKb);
		Console.WriteLine((memKb / 1024 / 1024) + " GB of RAM installed.");
	}
