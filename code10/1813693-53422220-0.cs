    using System;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string json = "{ \"values\": [{ \"id\": \"7ef82869-e235-69a2-f81e-3a9664e89bc4\",	\"value\": \"\" }] }";
    		JObject obj = JObject.Parse(json);
    		
    		// Check to see if we got our value array
    		if (obj.ContainsKey("values")) {
    			JArray values = (JArray)obj["values"];
    			
    			// Do we have any values in our array?
    			if (values.Count > 0) {
    				JObject firstItem = (JObject)values[0];
    				
    				// We check to see if we have an ID parameter
    				if (firstItem.ContainsKey("id")) {
    					Console.WriteLine(firstItem["id"]);
    				}
    			}
    		}
    	}
    }
