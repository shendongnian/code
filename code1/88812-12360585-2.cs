    public static class EnumUtils
    {
    	public static Nullable<T> Parse<T>(string input) where T : struct
    	{
    		//since we cant do a generic type constraint
    		if (!typeof(T).IsEnum)
    		{
    			throw new ArgumentException("Generic Type 'T' must be an Enum");
    		}
    
    		int intVal;
    		if (!string.IsNullOrEmpty(input) && !int.TryParse(input, out intVal))
    		{
    			T eVal;
    			if (Enum.TryParse(input, true, out eVal))
    			{
    				return eVal;
    			}
    		}
    		return null;
    	}
    }
