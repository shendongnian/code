    class TestChild<T>
    {
    	public T ChildProperty { get; set; }
    }
    
    class TestParent<T>
    { 
    	public TestChild<T> ParentProperty { get; set; }	
    }
    
    void Main()
    {
    	var instance = new TestParent<string>
    	{
    		ParentProperty = new TestChild<string>()
    	};
    	
    	instance.GetType()
    			.GetProperty("ParentProperty")
    			.GetValue(instance)
    			.GetType()
    			.GetProperty("ChildProperty")
    			.SetValue(instance.ParentProperty, "Value");
    	
    	Console.WriteLine(instance.ParentProperty.ChildProperty);
    }
