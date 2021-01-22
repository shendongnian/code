    using System;
    using System.Reflection;
    
    class Test
    {
    	static void Main()
    	{
    		Foo foo = new Foo();
    
    		PropertyInfo property = typeof(Foo).GetProperty("Bar");
    		Object value =
    			Convert.ChangeType("1234",
    				Nullable.GetUnderlyingType(property.PropertyType)
    				?? property.PropertyType);
    
    		property.SetValue(foo, value, null);
    	}
    }
    
    class Foo
    {
    	public Nullable<Int32> Bar { get; set; }
    }
