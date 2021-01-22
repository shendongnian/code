    public class MyClass
    {
    	public static void Main()
    	{
    		
    	}
    	
    	public void DirectCast(Object obj)
    	{
    		if ( obj != null)
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
