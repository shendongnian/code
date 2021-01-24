    public class Head
    		{
    			public IList<List<Dictionary<string, object>>> TestRows{ get; set; }
    		}
    
    		public class Cookie
    		{
    			public Head Head { get; set; }
    		}
	var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
				var path= Path.Combine(baseDirectory, "test.json");
				//deserialize JSON from file  
				string JsonStream = System.IO.File.ReadAllText(path, Encoding.Default);
				var DeserializedCookieList = JsonConvert.DeserializeObject<Cookie>(JsonStream);
