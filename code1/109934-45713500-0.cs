    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var list = new List<int>{1, 5, 4, 6, 8, 11, 3, 12};
    
    		int running_total = 0;
    		
    		list.ForEach(x=> Console.WriteLine(running_total = x+running_total));
    	}
    }
