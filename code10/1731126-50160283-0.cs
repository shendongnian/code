    var settings = new JsonSerializerSettings
    		{
    			DateParseHandling = DateParseHandling.None
    		};
    		
    		string json = "[{\"ID\":\"1\",\"DATETIME\":\"2018-05-02T00:00:00\"}, {\"ID\":\"1\",\"DATETIME\":\"\"}]";
    
    		var jsonObj = JsonConvert.DeserializeObject<DataTable>(json, settings);
    		
    		Console.WriteLine(jsonObj.Rows.Count);
    		
