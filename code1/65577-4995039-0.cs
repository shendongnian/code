	[STAThreadAttribute]
	public static void Main()
	{
		AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
		App.Main();
	}
