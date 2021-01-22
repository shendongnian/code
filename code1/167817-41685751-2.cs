    using System;
    using System.Linq;
    
    public static class EnumExtensions
    {
    	public static Enum GetRandomEnumValue(this Type t)
    	{
    		return Enum.GetValues(t)          // get values from Type provided
    			.OfType<Enum>()               // casts to Enum
    			.OrderBy(e => Guid.NewGuid()) // mess with order of results
    			.FirstOrDefault();            // take first item in result
    	}
    }
    					
    public static class Program
    {
    	public enum SomeEnum
    	{
    		One = 1,
    		Two = 2,
    		Three = 3,
    		Four = 4
    	}
    	
    	public static void Main()
    	{
    		for(int i=0; i < 10; i++)
    		{
    			Console.WriteLine(typeof(SomeEnum).GetRandomEnumValue());
    		}
    	}			
    }
