    public static class StringReplacementExtensions
    {
    	public static string Replace(this string source, Dictionary<string, string> values)
    	{
    		return values.Aggregate(
    			source,
    			(current, parameter) => current
                    .Replace($"{{{parameter.Key}}}", parameter.Value));
    	}
    	
    	public static string Replace(this string source, object values)
    	{
    		var properties = values.GetType().GetProperties();
    		
    		foreach (var property in properties)
    		{
    			source = source.Replace(
                    $"{{{property.Name}}}", 
                    property.GetValue(values).ToString());
    		}
    		
    		return source;
    	}
    }
