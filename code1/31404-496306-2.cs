    public class MyClass
    {
    	public static void Main()
    	{
    		// Call the 2 methods
    	}
    	
    	public void DirectCast(Object obj)
    	{
    		if ( obj is MyClass)
    		{ 
    			MyClass myclass = (MyClass) obj; 
    			Console.WriteLine(obj);
    		} 
    	} 
    	
    	  
    	public void UsesAs(object obj) 
    	{ 
    		MyClass myclass = obj as MyClass; 
    		if (myclass != null) 
    		{ 
    			Console.WriteLine(obj);
    		} 
    	}
    }
