    public class CustomAttribute : Attribute
    {
    		
    	public CustomAttribute(Type resourceType, string resourceName)
    	{
    			Message = ResourceHelper.GetResourceLookup(resourceType, resourceName);
    	}
    
    	public string Message { get; set; }
    }
    
    public class ResourceHelper
    {
    	public static  string GetResourceLookup(Type resourceType, string resourceName)
    	{
    		if ((resourceType != null) && (resourceName != null))
    		{
    			PropertyInfo property = resourceType.GetProperty(resourceName, BindingFlags.Public | BindingFlags.Static);
    			if (property == null)
    			{
    				throw new InvalidOperationException(string.Format("Resource Type Does Not Have Property"));
    			}
    			if (property.PropertyType != typeof(string))
    			{
    				throw new InvalidOperationException(string.Format("Resource Property is Not String Type"));
    			}
    			return (string)property.GetValue(null, null);
    		}
    		return null; 
		}
	}
    
