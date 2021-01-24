    using System;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(Add(1, 2, 3, 4, 5));		
    	}
    	
    	public static int Add(params int[] numbers) 
    	{
    	 	return numbers.Sum();
    	}
    }
