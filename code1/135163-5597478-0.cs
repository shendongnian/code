    public static RouteValueDictionary AnonymousObjectToHtmlAttributes(object htmlAttributes)
    {
    	RouteValueDictionary result = new RouteValueDictionary();
    	if (htmlAttributes != null)
    	{
    		foreach (System.ComponentModel.PropertyDescriptor property in System.ComponentModel.TypeDescriptor.GetProperties(htmlAttributes))
    		{
    			result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
    		}
    	}
    	return result;
    }
