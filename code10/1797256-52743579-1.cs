    public static void DeepCopy<T>(T target, T source)
    {
    	DeepCloneImpl(typeof(T), source, target);
    }
    public static T DeepClone<T>(T template)
    	where T : new()
    {
    	return (T)DeepCloneImpl(typeof(T), template);
    }
    private static object DeepCloneImpl(Type type, object template, object stump = null)
    {
    	if (template == null)
    	{
    		return null;
    	}
    
    	var clone = stump ?? Activator.CreateInstance(type);
    
    	var clonableProperties = type.GetProperties()
    		.Where(x => x.GetMethod != null && x.SetMethod != null);
    	foreach (var property in clonableProperties)
    	{
    		var propertyType = property.PropertyType;
    		if (propertyType.GetTypeInfo().IsValueType || propertyType == typeof(string))
    		{
    			var value = property.GetValue(template);
    			property.SetValue(clone, value);
    		}
    		else if (propertyType.GetTypeInfo().IsClass && propertyType.GetConstructor(Type.EmptyTypes) != null)
    		{
    			var value = DeepCloneImpl(propertyType, property.GetValue(template));
    			property.SetValue(clone, value);
    		}
    		else if (propertyType.IsArray)
    		{
    			var source = property.GetValue(template) as Array;
    			if (source == null)
    			{
    				continue;
    			}
    
    			var elementType = propertyType.GetElementType();
    			if (elementType.GetTypeInfo().IsValueType || elementType == typeof(string))
    			{
    				var copies = Array.CreateInstance(elementType, source.Length);
    				Array.Copy(source, copies, source.Length);
    				property.SetValue(clone, copies);
    			}
    			else if (elementType.GetTypeInfo().IsClass)
    			{
    				var copies = Array.CreateInstance(elementType, source.Length);
    				for (int i = 0; i < source.Length; i++)
    				{
    					var copy = DeepCloneImpl(elementType, source.GetValue(i));
    					copies.SetValue(copy, i);
    				}
    				property.SetValue(clone, copies);
    			}
    		}
    	}
    
    	return clone;
    }
