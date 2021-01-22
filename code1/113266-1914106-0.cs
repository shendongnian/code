    List<Type> list = new List<Type>();
    foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
    {
    	foreach (Type t in ass.GetExportedTypes())
    	{
    		if (t.IsEnum)
    		{
    			list.Add(t);
    		}
    	}
    }
