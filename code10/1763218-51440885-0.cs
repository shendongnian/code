    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq; 
    					
    public class Program
    {
    	public static void Main()
    	{		
    		string someJson =@"{
    			""FileLeafRef"": ""FILENAMEBOYS.jpg"",
    			""link"": {
    				""Description"": ""https://stackoverflow.com/questions/ask"",
    				""Url"": ""https://stackoverflow.com/questions/ask""
    			}
    		}";
    		var jObject = JObject.Parse(someJson);
    		var parentDict = jObject.ToObject<Dictionary<string, object>>();
    		foreach (var parentPair in parentDict) 
    		{
    			Console.Write(string.Format("Key: {0}, ", parentPair.Key));
    			if (parentPair.Value is JObject)
    			{
    				Console.WriteLine();
                    var childDict = ((JObject)parentPair.Value).ToObject<Dictionary<string, string>>();
    				foreach (var childPair in childDict) 
    				{
    					Console.WriteLine(string.Format("\tKey: {0}, Value: {1}", childPair.Key, childPair.Value));
    				}
    			}
    			else if (parentPair.Value is string)
    			{
    				Console.WriteLine(string.Format("Value: {0}", parentPair.Value));
    			}
        	}
    	}
    }
