    class TestType
    {
    	public int a;
    	public int b;
    }
    
    void Main()
    {
    	var typeName = typeof(TestType).FullName; // we have a string from here on
    	
    	var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.FullName == typeName); // get the type based on the name
    	
    	var obj = Activator.CreateInstance(type); // object of this type, but without compile time type info
    	
    	var member = type.GetField("a"); // we know, that this is a field, not a property	
    	member.SetValue(obj, 1); // we set value to 1
    	member = type.GetField("b");
    	member.SetValue(obj, 2); // we set value to 2
    	
    	Console.Write($"See values: a={((TestType)obj).a}, b={((TestType)obj).b}");
    }
