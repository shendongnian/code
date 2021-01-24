    JsonTestClass c = new JsonTestClass();
    c.Name = "test";
    c.Test = new JsonTestClass();
    
    string json = JsonConvert.SerializeObject
    	   (c, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
  
