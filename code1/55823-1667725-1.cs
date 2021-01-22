    using System.Reflection;    
    private string GetPropertyFromObject(string propertyName, object obj)
        {
        	PropertyInfo pi = obj.GetType().GetProperty(propertyName);
        	if(pi != null)
        	{
        		object value = pi.GetValue(obj, null);
        		if(value != null)
        		{
        			return value.ToString();
        		}
        	}
        	//return empty string, null, or throw error
        	return string.Empty;
        }
