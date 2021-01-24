    void Main()
    {
    	var json = @"
    	{
    		""success"": true,
    		""reason"": ""All good"",
    		""type"": ""B"",
    		""data"": {
    			""token"": ""1234-5678""
    		}
    	}";
    	var foo = JsonConvert.DeserializeObject<A>(json);
    	var type = Assembly.GetExecutingAssembly().GetTypes().Where(i => i.IsClass && i.Name == foo.Type).FirstOrDefault();
    	if (type == null)
    	{
    		throw new InvalidOperationException(string.Format("Type {0} not found", foo.Type));
    	}
    	var data = foo.Data.ToObject(type);
    }
    
    public class A
    {
    	public bool Success { get; set; }
    	public string Reason { get; set; }
    	public string Type { get; set; }
    	public JToken Data { get; set; }
    }
    
    public class B
    {
    	public string Token { get; set; }
    }
