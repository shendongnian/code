    public IEnumerable<T> FilterMyListRecursive<T>(IEnumerable<T> list, string searchpattern, params string [] propertynames) where T: class
    {
    	foreach (var element in list)
    	{		
    		if (TryNestedRecursiveDescend(element, searchpattern, propertynames))
    		{
    			yield return element;
    		}		
    	}
    }
    
    private bool TryNestedRecursiveDescend<T>(T obj, string searchpattern, params string [] propertynames) where T: class
    {	
    	var nestedValue = obj.GetType().GetProperty(propertynames.First()).GetValue(obj);
        // if you are at the lowest level that you can check
    	if (fieldvalues.Length == 1)
    	{		
    		return nestedValue.ToString().ToLower() == searchpattern;
    	}
    	else
    	{
            // recursive call with the remaining propertynames
    		return TryNestedDescend(nestedValue, searchpattern, propertynames.Skip(1).ToArray());
    	}
    }
