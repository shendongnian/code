    // TODO - Specify your folder containing DLLs to inspect
    static string DLL_FOLDER_PATH = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0";
    void Main()
    {
    	(from dllPath in Directory.GetFiles(DLL_FOLDER_PATH, "*.dll")
    	let assembly = dllPath.SafeLoad()
    	let build = assembly == null ? "Error" : (dllPath.SafeLoad().IsAssemblyDebugBuild() ? "Debug" : "Release")
    	select new {
    		Assembly_Path = dllPath,
    		Build = build,
    	}).Dump();
    }
    static class Extensions {
    	public static bool IsAssemblyDebugBuild(this Assembly assembly)
    	{
    	    return assembly.GetCustomAttributes(false).OfType<DebuggableAttribute>().Select(da => da.IsJITTrackingEnabled).FirstOrDefault();
    	}
    	public static Assembly SafeLoad(this string path){
    		try{
    			return Assembly.LoadFrom(path);
    		}
    		catch {
    			return null;
    		}
    	}
    }
