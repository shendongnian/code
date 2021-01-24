    using System;
    using System.Linq;
    
    class Level { } 
    class Levels 
    {
    	public Level level1;
    	public Level level2;
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(
              typeof(Levels)
                .GetFields()
                .Count(f => f.FieldType == typeof(Level)));
    	}
    }
