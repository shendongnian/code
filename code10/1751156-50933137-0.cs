    using System;
    using Newtonsoft.Json;
    					
    using Newtonsoft.Json.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var jsonString = "{\"startTime\" : { \"$date\" : \"2018-03-19T19:38:02.929Z\"}  }";
    		
    		var jObj = JsonConvert.DeserializeObject<JObject>(jsonString);
    		
    		Console.WriteLine(jObj);
    		
    		var jToken = jObj.SelectToken("startTime.$date");
    		
    		
    		
    		Console.WriteLine(jToken.Value<DateTime>());
    		Console.WriteLine("Hello World");
    	}
    }
