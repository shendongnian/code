    class Test 
    { 
    	public string Property { get; set; }	
    }
    
    void Main()
    {
    	var instance = new Test();
    	
    	typeof(Test).GetProperty("Property").SetValue(instance, "Value");
    	
    	Console.WriteLine(instance.Property);
    }
