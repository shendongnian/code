    JsonTestClass c = new JsonTestClass();
    c.Name = "test";
    c.test = c;
    string json = JsonConvert.SerializeObject
                   (c, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
