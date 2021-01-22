    void Main()
    {
    	var test = new TestObject();
    	test.a = "123";
    	test.b = "456";
    	var testProperties = (from prop in test.GetType().GetProperties() 
    							select new KeyValuePair<string,string>(prop.Name,prop.GetValue(test,null).ToString()));
    	foreach (var property in testProperties)
    	{
    		Console.WriteLine(string.Format("Name: {1}{0}Value: {2}",Environment.NewLine,property.Key,property.Value));
    	}
    }
    
    class TestObject
    {
    	public string a { get; set; }
    	public string b { get; set; }
    }
