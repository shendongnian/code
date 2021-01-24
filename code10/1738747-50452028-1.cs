    class Test<T>
    { 
    	public T Property { get; set; }	
    }
    
    void Main()
    {
    	var instance = new Test<string>();
    	
    	typeof(Test<string>).GetProperty("Property").SetValue(instance, "Value");
    	
    	Console.WriteLine(instance.Property);
    }
