    public class A
    {
    	// attributes and constructor here
    	public virtual dynamic Clone()
    	{
    		var clone = new A();
    		// Do more cloning stuff here
    		return clone;
    	}
    }
    
    public class B : A
    {
    	// more attributes and constructor here
    	public override dynamic Clone()
    	{
    		var clone = new B(); 	
    		// Do more cloning stuff here
    		return clone;
    	}
    }    
    public class Program
    {
    	public static void Main()
    	{
    		A a = new A().Clone();  // No cast needed here
    		B b = new B().Clone();  // and here
    		// do more stuff with a and b
    	}
    }
  
