    using System;
    					
    public class Program
    {
    	
    	public abstract class ObjectA { }
    	
    	public class ObjectB : ObjectA {}
    	
    	public class ObjectC : ObjectA {}
    	
    	public static void Main()
    	{
            // You may get this instance from anywhere
    		Object o = new ObjectB();
    		
    		if (o is ObjectB) 
    			DoSomething((ObjectB) o);
    		else if (o is ObjectC)
    			DoSomething((ObjectC) o);
    		
    	}
    	
    	
    	public static void DoSomething(ObjectB o) {
    		Console.WriteLine("Object B called");	
    	}
    	
    	public static void DoSomething(ObjectC o) {
    		Console.WriteLine("Object C called");	
    	}
    }
