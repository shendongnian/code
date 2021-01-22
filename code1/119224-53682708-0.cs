    using System;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		int i = 234;
    		int j = -123;
    		Console.WriteLine(reverse(i));
    		Console.WriteLine(reverse(j));
    	}
    
    	static int reverse(int i)
    	{
    		int sign = i / Math.Abs(i);
    		var abs = string.Concat(Math.Abs(i).ToString().Reverse());
    		return int.Parse(abs) * sign;
    	}
    }
