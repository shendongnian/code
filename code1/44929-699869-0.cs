    var _interfaceType = typeof(ISomething);
    var currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();
    var types = GetType().GetNestedTypes();
    
    foreach (var type in types)
    {
    	if (_interfaceType.IsAssignableFrom(type) && type.IsPublic && !type.IsInterface)
    	{
    		ISomething something = (ISomething)currentAssembly.CreateInstance(type.FullName, false);
    		something.TheMethod();
    	}
    }
