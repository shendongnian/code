	AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs args)
	{
		// Find name (first argument)
		string assemblyName = args.Name.Substring(0, args.Name.IndexOf(','));
		try
		{
			// Build the path to DLL and load it
			// WARNING: The path has to be absolute otherwise it will raise an ArgumentException (security)
			if (assemblyName == "FooBar")
			{
				return Assembly.LoadFile(@"C:\Absolute\Path\" + assemblyName + ".dll");
			}
			else if (assemblyName == "BarFooZor")
			{
				return Assembly.LoadFile(@"C:\Another\Absolute\Path\For\" + assemblyName + ".dll");
			}
		}
		catch (Exception) { }
		return null; // load failure
	};
