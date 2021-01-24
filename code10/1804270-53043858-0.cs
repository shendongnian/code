    using System;
    using  Newtonsoft.Json.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var json = "[{ \"response\" : { \"test\" : \"Value1\" } }, { \"response\" : [ { \"test\" : \"Value2\" }, { \"test\" : \"Value3\" }] }]";
    		var responseContainers = JArray.Parse(json);
    		
    		foreach(var responseContainer in responseContainers)
    		{
    			var response = responseContainer.Value<JToken>("response");
    			
    			if(response.Type == JTokenType.Object)
    			{
    				var data = response.ToObject<Data>();
    				Console.WriteLine("data: " + data.test);
    			}
    			else if(response.Type == JTokenType.Array)
    			{
    				var dataJArray = response.ToObject<JArray>();
    				
    				foreach(var dataJToken in dataJArray)
    				{
    					var data = dataJToken.ToObject<Data>();
    					Console.WriteLine("datas: " + data.test);
    				}
    			}
    		}
    	}
    }
    
    public class Data
    {
    	public string test { get;set; }
    }
