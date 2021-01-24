    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var text = "Some random words here EK/34 54/56/75 AB/12/34/56/BA1590/A and more random stuff...";
    		var whatImLookinFor = "12/34/56/";
    		
            // check if text contains it _at all_
    		if (text.Contains(whatImLookinFor))
    		{			
                // split the whole text at spaces as specified and retain those parts that 
                // contain your text
    			var split = text.Split(' ').Where(t => t.Contains(whatImLookinFor)).ToList();
                // print all results to console
    			foreach (var s in split)
    				Console.WriteLine(s);
    		}
    		else
    			Console.WriteLine("Not found");
    		
    		Console.ReadLine();
    	}
    }
