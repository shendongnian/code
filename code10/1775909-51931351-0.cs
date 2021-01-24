    using System;
    using System.Collections.Concurrent;
    
    public class MyClass
    {
    	public MyClass(string description)
    	{
    	}
    
    	public void Load()
    	{
    	}
    }
    
    public class MyClassLoader
    {
    	public static Lazy<ConcurrentBag<MyClass>> allLazy = new Lazy<ConcurrentBag<MyClass>>(() =>
    	{
    		ConcurrentBag<MyClass> bag = new ConcurrentBag<MyClass>();
    		bag.Add(new MyClass("first"));
    		bag.Add(new MyClass("second"));
    		bag.Add(new MyClass("third"));
    		bag.Add(new MyClass("fourth"));
    		foreach (MyClass item in bag)
    		{
    			item.Load();
    		}
    
    		return bag;
    	}
    
    	);
    	public static void Load()
    	{
    		foreach (MyClass item in allLazy.Value)
    		{
    		// Do whatever you want
    		}
    	}
    }
