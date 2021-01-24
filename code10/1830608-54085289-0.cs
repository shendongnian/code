    class Distance
    {
    	float d;
    	public Distance(float d)
    	{
    		this.d = d;
    	}
    	
    	public static Distance operator+(Distance op1, Distance op2)
    	{
    		return new Distance(op1.d + op2.d);
    	}
    
        // ==, !=, Equals and GetHashCode are not required but if you 
        // need one (i.e. for comparison you need ==, to use values of this 
        // type in Dictionaries you need GetHashCode)
        // you have to implement all 
    	public static bool operator == (Distance op1, Distance op2)
    	{
    		return op1.d == op2.d;
    	}
    	public static bool operator !=(Distance op1, Distance op2)
    	{
    		return op1.d != op2.d;
    	}
    
    	public override bool Equals(object obj)
    	{
    		return (object)this == obj || ((obj is Distance) && (obj as Distance)==this);
    	}
    	public override int GetHashCode()
    	{
    		return d.GetHashCode();
    	}
    
        // Some basic ToString so we can print it in Console/use in 
        // String.Format calls
    	public override string ToString()
    	{
    		return $"{d} M";
    	}
    }
