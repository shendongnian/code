    public enum Month
    {
        January,
        February,
        // (...)
        December,
    }    
    
    public Month ToInt(Month Input)
    {
    	return (Month)Enum.Parse(typeof(Month), Input, true));
    }
