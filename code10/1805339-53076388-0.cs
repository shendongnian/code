    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		int[] arr = {999999999, 999999999, 999999999,999999999, 999999999};
    		 long sum = 0;
    		 for (int i = 0; i < arr.Length; i += 1)
    		 {
    		   sum += arr[i];
    		 }
    		Console.WriteLine(sum);
    	}
    }
