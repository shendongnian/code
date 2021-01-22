    public static bool operator ==(BaseEntity a, BaseEntity b)
    {
    	return Object.Equals(a, b);
    }
    
    public static bool operator !=(BaseEntity a, BaseEntity b)
    {
    	return !Object.Equals(a, b);
    }
