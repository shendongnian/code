    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string text = "NS10 EW9 \n $1.91 \n \n $2.60 \n 42";
    		
    		List<String> split = text.Split(' ').ToList();
    		
    		foreach(string item in split)
    		{
    			Console.WriteLine("List Item:" + item);
    		}
    		
    	}
    }
