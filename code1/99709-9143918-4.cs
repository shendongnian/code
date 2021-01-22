    public static IDictionary<string,T> AnonymousObjectToDictionary<T>(
    	object obj, Func<object,T> valueSelect
    )
    {
    	return TypeDescriptor.GetProperties(obj)
    		.OfType<PropertyDescriptor>()
    		.ToDictionary<PropertyDescriptor,string,T>(
    			prop => prop.Name,
    			prop => valueSelect(prop.GetValue(obj))
    		);
    }
