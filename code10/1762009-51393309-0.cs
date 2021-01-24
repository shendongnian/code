    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(Add(1, 2, 3, 4, 5));		
    	}
    	
    	public static int Add(params int[] numbers) 
    	{
    	 	int sum = 0;
    		foreach (int n in numbers)
    		{
    			sum += n;
    		}
    		
    		return sum;
    	}
    }
