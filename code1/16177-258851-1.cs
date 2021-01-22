    public enum Month
    {
        January,
        February,
        // (...)
        December,
    }    
    
    public Month ToInt(Month Input)
    {
    	return (int)Enum.Parse(typeof(Month), Input, true));
    }
