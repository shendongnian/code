    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
    	static void Main()
    	{
    		String[] values = Regex.Split("hello,world", ",");
    
    		foreach (String value in values)
    			Console.WriteLine(value);
    	}
    }
