    class Test<T>
    { 
    	public T Property { get; set; }	
    }
    
    void Main()
    {
    	var instance = new Test<string>();
    	
    	instance.GetType().GetProperty("Property").SetValue(instance, "Value");
    	
    	Console.WriteLine(instance.Property);
    }
