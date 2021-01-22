    public static T GetPropertyValue<T>(object sourceInstance, string targetPropertyName, bool throwExceptionIfNotExists = false)
    {
    	string errorMsg = null;
    
    	try
    	{
    		if (sourceInstance == null || string.IsNullOrWhiteSpace(targetPropertyName))
    		{
    			errorMsg = $"Source object is null or property name is null or whitespace. '{targetPropertyName}'";
    			Log.Warn(errorMsg);
    
    			if (throwExceptionIfNotExists)
    				throw new ArgumentException(errorMsg);
    			else
    				return default(T);
    		}
    
    		Type returnType = typeof(T);
    		Type sourceType = sourceInstance.GetType();
    
    		PropertyInfo propertyInfo = sourceType.GetProperty(targetPropertyName, returnType);
    		if (propertyInfo == null)
    		{
    			errorMsg = $"Property name '{targetPropertyName}' of type '{returnType}' not found for source object of type '{sourceType}'";
    			Log.Warn(errorMsg);
    
    			if (throwExceptionIfNotExists)
    				throw new ArgumentException(errorMsg);
    			else
    				return default(T);
    		}
    
    		return (T)propertyInfo.GetValue(sourceInstance, null);
    	}
    	catch(Exception ex)
    	{
    		errorMsg = $"Problem getting property name '{targetPropertyName}' from source instance.";
    		Log.Error(errorMsg, ex);
    
    		if (throwExceptionIfNotExists)
    			throw;
    	}
    
    	return default(T);
    }
