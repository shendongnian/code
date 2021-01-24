    void Main()
    {
    	var a = new A();
    	a.CProperty = 42;
    }
    
   
    public class C {
    	public int CProperty { get; set; }
    }
    
    public class B : C
    {
    	// nothing
    }
    
    public class A : B{
    	// nothing
    }
