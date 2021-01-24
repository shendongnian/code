    using System;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
		var arrStr = "[78293270, 847744, 32816430]";
		var jArray = JArray.Parse(arrStr);
		
		foreach (var obj in jArray)
		{
			Console.WriteLine(obj);	
		}
		
		var aStr = "[\"aa\", \"bb\", \"cc\"]";
		var jArray1 = JArray.Parse(aStr);
		
		foreach (var obj in jArray1)
		{
			Console.WriteLine(obj);	
		}
		
	}
    }
		
