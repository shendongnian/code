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
	
	var testMethods = (from meth in test.GetType().GetMethods() select new { Name = meth.Name, Parameters = 
		(from param in meth.GetParameters() 
			select new {Name = param.Name, ParamType=param.GetType().Name})} );
			
	foreach (var method in testMethods)
	{
		Console.WriteLine(string.Format("Method: {0}",method.Name));
		foreach(var param in method.Parameters)
		{
			Console.WriteLine("Param: " + param.Name + " (" + param.ParamType + ")");
		}
	}
    }
    class TestObject
    {
	public string a { get; set; }
	public string b { get; set; }
	public string testMethod(string param1,int param2){return string.Empty;}
    }
    
    
