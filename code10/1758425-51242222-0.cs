    public string StringFormat(string input, object parameters)
    {
    	var properties = parameters.GetType().GetProperties();
    	var result = input;
    	
    	foreach (var property in properties)
    	{
    		result = result.Replace(
    			$"{{{{{property.Name}}}}}", //This is assuming your param names are in format "{{abc}}"
    			property.GetValue(parameters).ToString());
    	}
    	
    	return result;
    }
