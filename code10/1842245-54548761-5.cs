    public IEnumerable<T> FilterMyListRecursive<T>(IEnumerable<T> list, string searchpattern, params string [] fieldvalues) where T: class
    {
    	foreach (var element in list)
    	{		
    		if (TryNestedDescend(element, searchpattern, fieldvalues))
    		{
    			yield return element;
    		}		
    	}
    }
    
    private bool TryNestedDescend<T>(T obj, string searchpattern, params string [] fieldvalues)
    {	
    	var nestedValue = obj.GetType().GetProperty(fieldvalues.First()).GetValue(obj);
    	if (fieldvalues.Length == 1)
    	{		
    		return nestedValue.ToString().ToLower() == searchpattern;
    	}
    	else
    	{
    		return TryNestedDescend(nestedValue, searchpattern, fieldvalues.Skip(1).ToArray());
    	}
    }
