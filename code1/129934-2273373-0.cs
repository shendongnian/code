    // Start with Base class of all methods
    public class MyBase
    {
    	protected void Method1()
    	{
    
    	}
    
    	protected void Method2()
    	{
    
    	}
    
    	protected void Method3()
    	{
    
    	}
    
    	protected void Method4()
    	{
    
    	}
    }
    
    // Create a A base class only exposing the methods that are allowed to the A class
    public class MyBaseA : MyBase
    {
    	public new void Method1()
    	{
    		base.Method1();
    	}
    
    	public new void Method2()
    	{
    		base.Method2();
    	}
    }
    
    // Create a A base class only exposing the methods that are allowed to the B class
    public class MyBaseB : MyBase
    {
    	public new void Method3()
    	{
    		base.Method3();
    	}
    
    	public new void Method4()
    	{
    		base.Method4();
    	}
    }
    
    // Create classes A and B
    public class A : MyBaseA {}
    
    public class B : MyBaseB {}
    
    public class MyClass
    {
    	void Test()
    	{
    		A a = new A();
    
    		// No access to Method 3 or 4
    		a.Method1();
    		a.Method2();
    
    		B b = new B();
    
    		// No Access to 1 or 2
    		b.Method3();
    		b.Method4();
    
    
    	}
    }
