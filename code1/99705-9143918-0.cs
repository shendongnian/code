    public static IDictionary<string,object> AnonymousObjectToDictionary(object obj)
    {
    	return TypeDescriptor.GetProperties(obj)
    		.OfType<PropertyDescriptor>()
    		.ToDictionary(
    			prop => prop.Name,
    			prop => prop.GetValue(obj)
    		);
    }
