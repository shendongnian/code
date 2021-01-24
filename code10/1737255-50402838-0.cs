    public class A {
    	public string Id {get;set;}
    }
    public class B {
    	public string Id {get;set;}
    }
    
    void Main()
    {
    	var test = new A() { Id = "Test"};
    	var prop = test.GetType().GetProperty("Id");
    	
    	var b = (B)Activator.CreateInstance(typeof(B));
    	
    	var fromValue = prop.GetValue(test);
    	var converted = Convert.ChangeType(fromValue, prop.PropertyType);
    	prop.SetValue(b, converted, null); // Exception
    }
