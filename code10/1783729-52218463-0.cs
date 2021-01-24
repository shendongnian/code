     public static void Main(string[] args)
        {
            var derived = new Derived();
            var b = new Base();
    		D(derived); //Derived
            D(b); //Base
        }
    	
    	public static void D(Base base)
    	{
    		Console.WriteLine(base.GetType());
    			
    	}
