    using System;
    using System.Linq;
    
    public class Test
    {
    	public static void Main()
    	{
    		int[] x = {1,2,4,2,3,4,5,6};
    		int[] y =       {2,3};
       		int? index = null;
    		for(int i=0; i<x.Length; ++i)
    		{
    		    if (y.SequenceEqual(x.Skip(i).Take(y.Length)))
    		    {
    		    	index = i;
    		    	break;
    		    }
    		}
    		Console.WriteLine($"{index}");
    	}
    }
