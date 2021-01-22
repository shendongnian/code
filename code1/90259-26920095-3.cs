    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		var x = "Hello World";
    		foreach(var i in x.ChunkString(2)) Console.WriteLine(i);
    	}
    }
    
    public static class Ext{
    	public static IEnumerable<string> ChunkString(this string val, int chunkSize){
    		return val.Select((x,i) => new {Index = i, Value = x})
    				  .GroupBy(x => x.Index/chunkSize, x => x.Value)
    			      .Select(x => string.Join("",x));
    	}
    }
