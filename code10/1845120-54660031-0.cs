    using System;
    using System.Runtime;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string[] arrayOfItems = new string[5] {"Apple", "Banana", "Orange", "Apple", "Grape"};
    		
    		var arrayWithoutApples = arrayOfItems.Where(x => x != "Apple").ToArray();
    		
    		foreach(var item in arrayWithoutApples)
    		{
    			Console.WriteLine(item);	
    		}
    		
    		// Output:
            // Banana
            // Orange
            // Grape
    		
    	}
    }
