    public object GetPropertyValue(object obj, string propertyName)
    {
        object targetObject = obj;
        string targetPropertyName = propertyName;
    
        if (propertyName.Contains('.'))
        {
    	    string[] split = propertyName.Split('.');
    	    targetObject = obj.GetType().GetProperty(split[0]).GetValue(obj, null);
    	    targetPropertyName = split[1];
        }
    
        return targetObject.GetType().GetProperty(targetPropertyName).GetValue(targetObject, null);
    }
