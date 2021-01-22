    void Main()
    {
    	Console.WriteLine("before class constructor");
    	var test = new TestClass();
    	Console.WriteLine("after class constructor");
    	
    	var attrs = Attribute.GetCustomAttributes(test.GetType()).Dump();
    	foreach(var attr in attrs)
    		if (attr is TestClassAttribute)
    			Console.WriteLine(attr.ToString());
    }
    
    public class TestClassAttribute : Attribute
    {
    	public TestClassAttribute()
    	{
    		DefaultDescription = "hello";
    		Console.WriteLine("I am here. I'm the attribute constructor!");
    	}
    	public String CustomDescription {get;set;}
    	public String DefaultDescription{get;set;}
    	
    	public override String ToString()
    	{
    		return String.Format("Custom: {0}; Default: {1}", CustomDescription, DefaultDescription);
    	}
    }
    
    [Serializable]
    [TestClass(CustomDescription="custm")]
    public class TestClass
    {
    	public int Foo {get;set;}
    }
