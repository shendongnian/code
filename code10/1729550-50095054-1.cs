    public static async Task<List<Assembly>> GetReferecedAssemblies()
    {
    	List<Assembly> refAssemblies = new List<Assembly>();
    
    	var allFiles = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFilesAsync();
    	var filteredFiles = allFiles.Where(file => file.FileType == ".dll" || file.FileType == ".exe");
    
    	if (filteredFiles != null && filteredFiles.Count() > 0)
    	{
    		foreach (var file in filteredFiles)
    		{
    			try
    			{
    				refAssemblies.Add(Assembly.Load(new AssemblyName(file.DisplayName)));
    			}
    			catch (Exception ex)
    			{
    			}
    		}
    	}
    	
    	return refAssemblies;
    }
