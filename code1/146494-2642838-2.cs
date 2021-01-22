    private static List<string> GetInstanceList(string type, string filter)
    {
    	//get all classes implementing FilterType Attribute
    	var dict = AppDomain.CurrentDomain.GetAssemblies().
    				SelectMany(x => x.GetTypes()).
    				Where(x => x.GetCustomAttributes(typeof(FilterType), false).Length > 0).
    				Select(x => new { ((FilterType)x.GetCustomAttributes(typeof(FilterType), false)[0]).Filter, x }).
    				ToDictionary(x => x.Filter);
    
    	Filter_Base instance = (Filter_Base)Activator.CreateInstance(dict[type].x, filter);
    
    	var methods = instance.GetType().GetMembers().
    					Where(x => x.GetCustomAttributes(typeof(FilterMethod), true).Length > 0).
    					Select(x => new { ((FilterMethod)x.GetCustomAttributes(typeof(FilterMethod), true)[0]).Filter, x }).
    					ToDictionary(x => x.Filter);
    
    	
    	return (List<string>)instance.GetType().GetMethod(methods[filter].x.Name).Invoke(instance, null);
    }
