    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		var sample1 = new MyClass{Id = (decimal)0};
    		var sample2 = new MyClass{Id = (int)0};
    		var sample3 = new MyClass{Id = (byte)0};
    		
    		var property = typeof (MyClass).GetProperty(nameof(MyClass.Id));
    		
    		property.SetValue(sample1, Convert.ChangeType((decimal)10, property.PropertyType));
    		property.SetValue(sample2, Convert.ChangeType((int)10, property.PropertyType));
    		property.SetValue(sample3, Convert.ChangeType((byte)10, property.PropertyType));
    	
    		Console.WriteLine(sample1.Id);
    		Console.WriteLine(sample2.Id);
    		Console.WriteLine(sample3.Id);
    	}
    }
    
    public class MyClass
    {
    	public decimal Id
    	{
    		get;
    		set;
    	}
    }
