    using System;
    using System.Reflection;
    
    class Test
    {
    	public String X { get; set; }
    
    	Test(String x)
    	{
    		this.X = x;
    	}
    }
    
    class Program
    {
    	static void Main()
    	{
    		Type type = typeof(Test);
    
    		ConstructorInfo c = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, 
    			null, new Type[] { typeof(String) }, null);
    
    		Object o = c.Invoke(new Object[] { "foo" });
    	}
    }
