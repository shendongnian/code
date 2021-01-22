    using System; 
    using System.Reflection; 
     
     
    public static class ObjectHelper<t> 
    { 
    	public static int Compare(T x, T y) 
    	{ 
    		Type type = typeof(T); 
    		var publicBinding = BindingFlags.DeclaredOnly | BindingFlags.Public;
    		PropertyInfo[] properties = type.GetProperties(publicBinding); 
    		FieldInfo[] fields = type.GetFields(publicBinding); 
    		int compareValue = 0; 
     
     
    		foreach (PropertyInfo property in properties) 
    		{ 
    			IComparable valx = property.GetValue(x, null) as IComparable; 
    			if (valx == null) 
    				continue; 
    			object valy = property.GetValue(y, null); 
    			compareValue = valx.CompareTo(valy); 
    			if (compareValue != 0) 
    				return compareValue; 
    		} 
    		foreach (FieldInfo field in fields) 
    		{ 
    			IComparable valx = field.GetValue(x) as IComparable; 
    			if (valx == null) 
    				continue; 
    			object valy = field.GetValue(y); 
    			compareValue = valx.CompareTo(valy); 
    			if (compareValue != 0) 
    				return compareValue; 
    		} 
    	return compareValue; 
    	} 
    }
