    using System;
    using System.Collections.Generic;
					
    public class Program
    {
    	public static void Main()
    	{
    		var batches = Batchify( 453, 200);
    		Console.WriteLine(batches.Count);
    		foreach( Batch batch in batches )
    		{
    			Console.WriteLine("{0}-{1}", batch.Start, batch.End);
    		}
    	}
    	
    	public static List<Batch> Batchify( int number, int size)
    	{
    		List<Batch> result = new List<Batch>();
    		
    		int running = number;
    		int startIndex = 0;
    		
    		do
    		{
    			int endIndex = running < size ? startIndex+running : startIndex+size-1;
    			result.Add(new Batch{ Start = startIndex, End = endIndex });
    			startIndex = endIndex+1;
    			running -= size;
    		}while(running > 0);
    		
    		return result;
    	}
    }
    
    public class Batch
    {
    	public int Start{get;set;}
    	public int End{get;set;}
    }
