    var types = new List<Type>() { typeof(SomeImmutablePoco) }; // get all types using reflection
    foreach (var type in types)
    {
    	foreach (var ctor in type.GetConstructors())
    	{
    		var props = type.GetProperties(bindingAttr: System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
    		foreach (var param in ctor.GetParameters())
    		{
    			if (!props.Select(prop => prop.Name.ToLower()).Contains(param.Name.ToLower()))
    			{
    				Console.WriteLine($"The type {type.FullName} may have problems with Deserialization");
    			}
    		}
    	}
    }
