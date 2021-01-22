	[DllImport("kernel32", SetLastError=true)]
	static extern bool FreeLibrary(IntPtr hModule);
	public static void UnloadModule(string moduleName)
	{
        foreach(ProcessModule mod in Process.GetCurrentProcess().Modules)
        {
        	if(mod.ModuleName == moduleName)
        	{
        		FreeLibrary(mod.BaseAddress);
        	}
        }
	}
