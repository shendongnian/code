    public static bool IsTeamCity
    {
        get
        {
            // the Assembly.GetExecutingAssembly().Location property gives funny results when using 
            // NUnit (where assemblies run from a temporary folder), so the use of CodeBase is preferred.
            string codeBase = Assembly.GetCallingAssembly().CodeBase;
            string assemblyFullPath = Uri.UnescapeDataString(new UriBuilder(codeBase).Path);
            string assemblyDirectory = Path.GetDirectoryName(assemblyFullPath);
    
            // a full TeamCity build directory would be e.g. 'D:\TeamCity\buildAgent\work\de796548775cea8e\build\Compile'
            return assemblyDirectory.ToLowerInvariant().Contains("buildagent\\work");
        }
    }
