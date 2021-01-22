    public void MyMethod(string arg1, bool arg2, int arg3, int arg4)
    {
    	var dictionary = new PropertyDictionary(new 
    	{ 
    		arg1, arg2, arg3, arg4 
    	});
    }
    
    public class PropertyDictionary : Dictionary<string, object>
    {
    	public PropertyDictionary(object values)
    	{
    		if(values == null)
    			return;
    		
    		foreach(PropertyDescriptor property in TypeDescriptor.GetProperties(values))
    			Add(property.Name, property.GetValue(values);	
    	}
    }    
