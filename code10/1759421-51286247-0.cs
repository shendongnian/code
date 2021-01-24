	private static string GetApplicationPath()
	{
		string assemblyPath = Assembly.GetEntryAssembly().CodeBase;
		assemblyPath = new Uri(assemblyPath).LocalPath;
		assemblyPath = Path.GetDirectoryName(assemblyPath);
		return assemblyPath;
	}
