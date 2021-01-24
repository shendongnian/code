    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace StackOverflow
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var item = "{\"messageType\":\"0\",\"code\":\"1\"}";
    
    			var t = JsonConvert.DeserializeObject(item);
    			var x = JsonConvert.SerializeObject(t, Formatting.Indented);
    
    			string sPrettyStr;
    			var item2 = "{\"messageType\":\"0\",\"code\":\"1\"}";
    			sPrettyStr = JToken.Parse(item2).ToString(Formatting.Indented);
    
    			Console.WriteLine(x);
    			Console.WriteLine(sPrettyStr);
    			Console.ReadLine();
    		}
    	}
    }
