    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    
    	public static void Main()
    	{	
    	
    		var NewClassInstance = Singleton.GetSingleton().NewClassInstance;
    	    Singleton.GetSingleton().NewClassInstance.Method();
    		var OtherClassInstance = Singleton.GetSingleton().OtherClassInstance;
    		var Proparty  = OtherClassInstance.Name;
    	}
    }
    
    
    
    public class Singleton
    {
    	public NewClass NewClassInstance {get; private set;}
    	public OtherClass OtherClassInstance {get; private set;}
    
    
    	private static readonly NewClass _newClass = new NewClass();
    	private static readonly OtherClass _otherClass = new OtherClass();
    	private static readonly Singleton _singleton = new Singleton();
    	private Singleton()
    	{
    		NewClassInstance = _newClass;
    		OtherClassInstance = _otherClass;
    		// Prevent outside instantiation
    	}
    
    	public static Singleton GetSingleton()
    	{
    		return _singleton;
    	}
    }
    
    public class NewClass
    {
    	public NewClass()
    	{
    	}
    
    	public void Method()
    	{
    	}
    }
    
    
    public class OtherClass
    {
    	public string Name {get; set;}
    	
    	public OtherClass()
    	{
    	}
    }
