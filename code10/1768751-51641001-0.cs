    public class Program
    {
    	public static void Main()
    	{
    		A a;
            a = new A { b = new B { c = 5 } };
    		Console.WriteLine(a?.b.c);        // returns 5;
    		Console.WriteLine((a?.b).c);      // returns 5;
    		
    		a = null;
    		
    		Console.WriteLine(a?.b.c ?? -1);  // returns -1;
    		Console.WriteLine((a?.b).c);      // throws NullReferenceException
    		
            // Similar to a?.b.c
    		if (a != null)
    		    Console.WriteLine(a.b.c);     // returns 5;
    		else
    			Console.WriteLine(-1);        // returns -1;
    
            // Similar to (a?.b).c
    	    B tmp;
    		if (a != null)
    		    tmp = a.b;
    		else
    			tmp = null;
    		
    		Console.WriteLine(tmp.c);         // returns 5 or throws NullReferenceException
    	}
    }
    
    
    public class A
    {
    	public B b { get; set; }
    }
    
    public class B
    {
    	public int c { get; set; }
    }
