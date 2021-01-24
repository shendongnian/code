    void Main()
    {
    	var s = new StringBuilder();
    	s.Append("Id,Name\r\n");
    	s.Append("1,one\r\n");
    	s.Append("2,two\r\n");
    	using (var reader = new StringReader(s.ToString()))
    	using (var csv = new CsvReader(reader))
    	{
    		CsvHelper.ObjectResolver.Current = new ObjectResolver(CanResolve, Resolve);
    		csv.Configuration.RegisterClassMap<TestMap>();
    		csv.GetRecords<Test>().ToList().Dump();
    	}
    }
    
    public bool CanResolve(Type type)
    {	
    	return type == typeof(Test);
    }
    
    public object Resolve(Type type, object[] constructorArgs)
    {	
    	// Get a dependency from somewhere.
    	var someDependency = new object();
    	
    	return new Test(someDependency);
    }
    
    public class Test
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	
    	public Test(object someDependency) { }
    }
    
    public class TestMap : ClassMap<Test>
    {
    	public TestMap()
    	{
    		Map(m => m.Id);
    		Map(m => m.Name);
    	}
    }
