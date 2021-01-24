    using System;
    using System.Linq;
    			
    class Cls
    {
    	public string Prop1 {get; set;}
    	
    	public object Prop2 {get; set;}
    	
    	public int Prop3 {get; set;}
    	
    	public string Prop4 {get; set;}
    	
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var obj = new Cls() { Prop1 = "abc", Prop3 = 5 };
    		
    		var props = obj
    			.GetType()
    			.GetProperties()
    			.Select(p => p.GetValue(obj))
    			.Where(x => x != null || ( x is string && (string)x != ""))
    			.ToList();
    		
    		Console.WriteLine(string.Join(",", props));
    	}
    }
