    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int[] sa = {1, 2, 3, 4, 5, 15};
    		int[] sr = {2, 3, 5};
    
    		var r1 = sa.Where(l => !sr.Contains(l));
    		var r2 = sa.Except(sr);
    
    		var r3 = string.Join(",", sa.Except(sr));
    		
    		foreach (var i in r1)
    		{
    			Console.Write(i + ", ");
    		}
    		Console.WriteLine();
    		
    		foreach (var j in r2)
    		{
    			Console.Write(j + ", ");
    		}
    		Console.WriteLine();
    		
    		Console.WriteLine(r3);
    
    	}
    }
