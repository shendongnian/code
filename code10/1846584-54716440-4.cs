    public class Immutable
    {
    	public int X {get; private set;}
    
        public Immutable(int x)
    	{
    		X = x;
    	}
    }
    
    public class Mutable
    {
    	public int X {get; set;}
    
        public Mutable(int x)
    	{
    		X = x;
    	}
    }
