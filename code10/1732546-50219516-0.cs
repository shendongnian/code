    static void Main(string[] args)
    {
    	var salaried = new Salaried();
    	var hourly = new Hourly();
    	salaried.PayMe(100);
    	hourly.PayMe(100, 8);
    }
    
    class Salaried { }
    class Hourly { }
    
    static class ExtensionMethods
    {
    	public static void PayMe(this Salaried salaried, int salary)
    	{
    		// Do something
    	}
    
    	public static void PayMe(this Hourly hourly, int salary, int hours)
    	{
    		// Do something
    	}
    }
