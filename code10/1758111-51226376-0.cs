    public class Program
    {
    	public static void Main()
    	{
    	   Setup<Test>(DummyMethod2);
           Setup<Test>(x=>x.DummyMethod); //not allowed
    	}
    	
    	public static void Setup<T>(Action<T> expression)
    	{
    		
    	}
    	
    	public static void DummyMethod2(Test xd)
    	{
    		
    	}
    }
    
    public class Test
    {
    	public void DummyMethod()
    	{
    		
    	}
    }
