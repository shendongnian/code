    static T HandleEnumViaGeneric<T>(int id)
    {
    	if(!typeof(T).IsEnum)
    		throw new Exception("");
    
    	var values = Enum.GetValues(typeof(T));  
    	return (T)values.GetValue(id);
    }
