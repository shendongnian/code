    using System;
    using Newtonsoft.Json.Linq;
    public class Program
    {
    	public static void Main()
    	{
    		var str = "[\"Administrator\",\"Basant Sharma\"]";
            var items = JsonConvert.DeserializeObject<string[]>(str);
    		foreach (var item in items) {
			    Console.WriteLine("Item: {0}", item);
		    }
    	}
    }
