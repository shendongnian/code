    public static Random RNG = new Random();
    
    public static T RandomEnum<T>()
    {  
    	Type type = typeof(T);
    	Array values = Enum.GetValues(type);
    	object value= values.GetValue(RNG.Next(values.Length));
    	return (T)Convert.ChangeType(value, type);
    }
