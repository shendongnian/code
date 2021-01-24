    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		ArrayList aList = new ArrayList() { 1 , 2, 1 };
    		IEnumerable<int> result = aList.ToArray().ToList().Cast<int>().Where(v => v != 1).ToList();
    		
    		foreach(int item in result)
    		{
    			Console.WriteLine(item);
    		}
    	}
    }
