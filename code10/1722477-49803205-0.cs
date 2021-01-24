    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var myList = new List<SomeObj>() { new SomeObj(1, 10), new SomeObj(1, 20) };
    		
    		var sum = myList
                 // filter for values of foo that equal 1
                .Where(c => c.foo == 1)
                 // accumulate those values 
                .Aggregate(0m, (decimal acc, SomeObj next) => acc += next.prop);
    		
    		Console.WriteLine(sum);
    	}
    }
    
    public class SomeObj
    {
    	public int foo { get; set; } = 1;
    	public int prop { get; set; } = 10;
    	
    	public SomeObj(int foo, int prop)
    	{
    		this.foo = foo;
    		this.prop = prop;
    	}
    
    }
