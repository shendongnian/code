    static T HandleEnumViaGeneric<T>(int id)
    {
    	if(!typeof(T).IsEnum)
    		throw new Exception("");
    
    	var values = Enum.GetValues(typeof(T));
    
    	if (values.GetValue(id) == null)
    		throw new Exception("");
    
    	return (T)values.GetValue(id);
    }
