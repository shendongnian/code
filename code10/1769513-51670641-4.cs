    public class JsonTestClass
	{
		public string Name { get; set; }
		public List<int> MyIntList { get; set; }
		public JsonTestClass Test{get;set;}
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			JsonTestClass jtc = (JsonTestClass)obj;
			return true;
	   }
	}
    JsonTestClass c = new JsonTestClass();
    c.Name = "test";
    c.Test = c;
    string json = JsonConvert.SerializeObject
                   (c, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
