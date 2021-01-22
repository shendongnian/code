    using System;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
        Console.WriteLine(ToLiteral( @"abc\n123") );
    	}
    
    	private static string ToLiteral(string input){
    		return JsonConvert.DeserializeObject<string>("\"" + input + "\"");
    	}
    }
