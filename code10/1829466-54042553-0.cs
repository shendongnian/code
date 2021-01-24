    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var list = (new [] {1,2,3}).Select(i => new {Value=i}).ToList();
    		list.Add(new {Value=4});
    		
    		foreach (var i in list)
    			Console.WriteLine(i);
    	}
    }
