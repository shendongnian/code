    using Newtonsoft.Json.Linq;
    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		{
    			string sb = "			{\"properties\": {" +
    				"    \"type\": {" +
    				"      \"description\": \"Defines type of object being represented\"," +
    				"      \"type\": \"string\"," +
    				"      \"enum\": [" +
    				"        \"employee\"" +
    				"      ]" +
    				"    }," +
    				"    \"employeeFirstName\": {" +
    				"      \"title\": \"First Name\"," +
    				"      \"description\": \"Employee first name\"," +
    				"      \"type\": \"string\"" +
    				"    }," +
    				"    \"employeeLastName\": {" +
    				"      \"title\": \"Last Name\"," +
    				"      \"description\": \"Employee Last name\"," +
    				"      \"type\": \"string\"" +
    				"    }," +
    				"    \"address\": {" +
    				"      \"title\": \"Address\"," +
    				"      \"description\": \"Employee present address \"," +
    				"      \"$ref\": \"#/definitions/address\"" +
    				"        }" +
    				"}}";
    			var jsonObject = JObject.Parse(sb);
    			
    			var props = jsonObject.GetValue("properties");
    			
    			foreach (var prop in props.Values<JProperty>())
    			{
    				switch (prop.Name)
    				{
    					case "type":
    					Console.WriteLine("Handling type: " + prop.Value);
    					break;
    					case "employeeFirstName":
    					Console.WriteLine("employeeFirstName: " + prop.Value);
    					break;
    				}
    			}
    		}
    	}
    }
