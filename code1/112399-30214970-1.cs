	/// <summary>
	/// Here is the list of authorized assemblies (DLL files)
	/// You HAVE TO specify each of them and call InitializeAssembly()
	/// </summary>
	private static string[] LOAD_ASSEMBLIES = { "FooBar.dll", "BarFooFoz.dll" };
	/// <summary>
	/// Call this method at the beginning of the program
	/// </summary>
	public static void initializeAssembly()
	{
		AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs args)
		{
			string assemblyFile = (args.Name.Contains(','))
				? args.Name.Substring(0, args.Name.IndexOf(','))
				: args.Name;
			
			assemblyFile += ".dll";
			// Forbid non handled dll's
			if (!LOAD_ASSEMBLIES.Contains(assemblyFile))
			{
				return null;
			}
			string absoluteFolder = new FileInfo((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).LocalPath).Directory.FullName;
			string targetPath = Path.Combine(absoluteFolder, assemblyFile);
			try
			{
				return Assembly.LoadFile(targetPath);
			}
			catch (Exception)
			{
				return null;
			}
		};
	}
