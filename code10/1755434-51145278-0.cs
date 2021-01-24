    public static bool IsExpandoObject(object objectValue)
    {
    	if (objectValue == null)
    		return false;
    
    	if (IsDynamicObject(objectValue.GetType()))
    	{
    		IDictionary<string, object> expandoPropertyValues = objectValue as IDictionary<string, object>;
    		return expandoPropertyValues != null;
    	}
    
    	return false;
    }
    
    public static bool IsDynamicObject(Type type)
    {
    	return typeof(IDynamicMetaObjectProvider).IsAssignableFrom(type);
    }
