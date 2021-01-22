    private static Type GetBusinessEntityType(string typeName)
    {
        Debug.Assert(typeName != null);
    
        List<System.Reflection.Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.FullName.StartsWith("AF.BusinessEntities")).ToList();
    			
        foreach (var assembly in assemblies)
        {
            Type t = assembly.GetType(typeName, false);
            if (t != null)
                return t;
        }
        throw new ArgumentException(
            "Type " + typeName + " doesn't exist in the current app domain");
    }
