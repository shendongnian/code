    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    
        public class Program
        {
        	public static void Main()
        	{
        		string json="[{\"name\":\"someName\",\"id\":10,\"state\":\"someState\"},{\"name\":\"someName\",\"id\":10,\"state\":\"someState\"}]";
        		string json2="[{\"name\":\"someName\",\"id\":10,\"state\":\"someState\"}]";
        		var result1 = JsonConvert.DeserializeObject<List<RootObject>>(json);
        		var result2 = JsonConvert.DeserializeObject<List<RootObject>>(json2);
        		Console.WriteLine("result1 count="+result1.Count());
        		Console.WriteLine("result2 count="+result2.Count());
        		
        	}
        	
        	
        	
        }
        public class RootObject
        {
            [JsonProperty("name")]
            public string Name{ get; set; }
        
            [JsonProperty("id")]
            public int Id { get; set; }
        
            [JsonProperty("state")]
            public string State { get; set; }
        }
