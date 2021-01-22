    public static IEnumerable<string> GetReferencesAssembliesPathes(this Type type)
    {			
    	yield return type.Assembly.Location;
    
    	foreach (AssemblyName assemblyName in type.Assembly.GetReferencedAssemblies())
    	{
    		yield return Assembly.ReflectionOnlyLoad(assemblyName.FullName).Location;
    	}
    }
