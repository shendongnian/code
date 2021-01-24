    using System;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var defaultObj = new MasterObject();
    		var notDefaultObject = new MasterObject();
    		
    		var defaultJson = JsonConvert.SerializeObject(defaultObj);
    		var notDefaultJson = JsonConvert.SerializeObject(notDefaultObject);
    		
    		Console.WriteLine("First Test");
    		if (defaultJson == notDefaultJson) 
    			Console.WriteLine("Same thing");
    		else
    			Console.WriteLine("Not same thing");
    		
    		notDefaultObject.Sub1.SomeObject.SomeOtherValue = "Not a default Value";
    		
    		notDefaultJson = JsonConvert.SerializeObject(notDefaultObject);
    				
    		Console.WriteLine("Second Test");
    		if (defaultJson == notDefaultJson) 
    			Console.WriteLine("Same thing");
    		else
    			Console.WriteLine("Not same thing");
    		
    	}
    
    }
    
    
    public class MasterObject 
    {
    	public SubObject1 Sub1 { get; set; }
    	public SubObject2 Sub2 { get; set; }
    	public string SomeString { get; set; }
    	
    	public MasterObject()
    	{
    		Sub1 = new SubObject1();
    		Sub2 = new SubObject2();
    		SomeString = "Some Default String";
    	}
    }
    
    public class SubObject1 
    {
    	public string SomeValue { get; set; }
    	public SubObject2 SomeObject { get; set; }
    	
    	public SubObject1()
    	{
    		SomeObject = new SubObject2();
    		SomeValue = "Some other Default String";
    	}
    }
    
    public class SubObject2
    {
    	public string SomeOtherValue { get; set; }
    	
    	public SubObject2()
    	{
    		SomeOtherValue = "Some default";
    	}
    }
