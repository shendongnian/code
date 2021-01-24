    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	private static IDictionary<string,object> MapData( JObject source, IDictionary<string,string> map ) {
    		var result = new Dictionary<string, object>();
    		foreach (var kvp in map) {
    			result.Add( kvp.Key, source.SelectToken( kvp.Value ).Value<object>() );
    		}
    		return result;
    	}
    	
    	public static void Main()
    	{
    		string jsonContent = @"{
        ""Name"" : ""Hello"",
        ""This"" : {
            ""That"" : {
                ""TheOther"" : ""There""
            }
        }
    }";
    		string jsonMap = @"{
        ""Test_Name"" : ""Name"",
        ""Test_Value"": ""This.That.TheOther""
     }";
    		var sourceObject = JsonConvert.DeserializeObject<JObject>( jsonContent );
    		var sourceMap = JsonConvert.DeserializeObject<IDictionary<string, string>>( jsonMap );
    		
    		var result = MapData( sourceObject, sourceMap );
    		foreach (var kvp in result) {
    			Console.WriteLine( "{0}: {1}", kvp.Key, kvp.Value );
    		}
    	}
    }
