    using System;
    using System.Text.RegularExpressions;
    using System.Web.Script.Serialization;
    
    namespace jsonhratky
    {
    	public static class Program {
    		
    		public static void Main(string[] args)
    		{
    			var instance = new JsonParsingTest();
    		}
    	}
    	
    	public class JsonParsingTest
    	{
    		class Response {
    	        public Client client;
    	    }
    	    
    	    class Client {
    	        public bool isWebLogin;
    	        public string registryName;
    	        public string walletCode;
    	    }
    		
    		const string JSON_EXAMPLE = ("{" + ("\"client\":{" + ("\"isWebLogin\":false," + ("\"registryName\": \"mpdemo\"," + ("\"walletCode\": \"Local\"" + ("}" + "}"))))));
    			
    		public JsonParsingTest() {
    			// Solution #1 using JavaScriptSerializer
    			var serializer = new JavaScriptSerializer();
    			Response parsed = serializer.Deserialize<Response>(JSON_EXAMPLE);
    			Console.WriteLine("parsed isWebLogin: " + parsed.client.isWebLogin);
                Console.WriteLine("parsed registryName: " + parsed.client.registryName);
                Console.WriteLine("parsed walletCode: " + parsed.client.walletCode);
    	        
                // Solution #2 (not recommended)
                var matches = Regex.Match(JSON_EXAMPLE, "registryName\":.*?\"([^\"]+)\"", RegexOptions.Multiline);
                if (matches.Success) {
                	Console.WriteLine("registryName parsed using Regex: " + matches.Groups[1].Value);
                } else {
                	Console.WriteLine("Solution using Regex failed.");
                }
                
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
    		}
    	}
    }
