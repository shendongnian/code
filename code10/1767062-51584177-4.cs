    using System.Collections.Generic;
    using System.Linq;
    using static System.Console;
    using System;
    using System.Text;
    					
    public class Program
    {
    	
    	public static void Main()
    	{
    		var result = Transform("aaaaa");
    		result.ToList().ForEach(WriteLine);
    	}
    	
    	public static IEnumerable<string> Transform(string str)
    	{
    		var result = new StringBuilder(str.ToLower()); 
    		for( int i = 0; i < str.Length; i++)
    		{ 
    			result[i] = char.ToUpper(str[i]);
    			yield return result.ToString();
    			result[i] = char.ToLower(str[i]);
    		}
    	}
    }
