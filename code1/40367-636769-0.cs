    using System;
    using System.DirectoryServices;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string path = @"IIS://Localhost/W3SVC/1/root/MyApp";
    			Console.WriteLine(GetAspNetVersion(path));
    		}
    
    		private static string GetAspNetVersion(string path)
    		{
    			using (DirectoryEntry app = new DirectoryEntry(path))
    			{
    				PropertyValueCollection pvc = app.Properties["ScriptMaps"];
    
    				foreach (string scriptMap in pvc)
    				{
    					if (scriptMap.StartsWith(".aspx"))
    					{
    						string[] mapping = scriptMap.Split(',');
    						string scriptProcessor = mapping[1];
    
    						// The version numbers come from the path
    						// C:\Windows\Microsoft.NET\Framework\
    						// which will be present in the script processor DLL path
    						if (scriptProcessor.Contains("v1.1.4322"))
    						{
    							return "1.1";
    						}
    
    						if (scriptProcessor.Contains("v2.0.50727"))
    						{
    							return "2.0";
    						}
    					}
    				}
    				throw new Exception("Unknown version ASP.NET version.");
    			}
    		}
    	}
    }
