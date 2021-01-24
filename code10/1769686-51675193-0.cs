    void Main()
    {
    	Dictionary<string, (string Foo, bool Bar)> spColumnMapping = new Dictionary<string, (string, bool)>();
    	
    	spColumnMapping.Add("foo", ("Quax", false));
    	
    	var x = spColumnMapping["foo"];
    	
    	Console.WriteLine(x.Foo); // prints Quax
    	Console.WriteLine(x.Bar); // prints False
    }
