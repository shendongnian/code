	public static string CreateCustomJSON(string serviceName, string value)
    {
        var v = new Dictionary<string,string> {{serviceName, value}};
        string json = JsonConvert.SerializeObject(v);
        Console.WriteLine(json);
        return json;
    }
	
	public static void Main()
	{
		CreateCustomJSON("service1", "hello");
		CreateCustomJSON("service2", "John");
	}
