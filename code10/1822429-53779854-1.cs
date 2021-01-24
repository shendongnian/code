    void Main()
    {
    	var value = new A();
    	Debug.WriteLine("Original value:");
    	value.Dump();
    
    	Debug.WriteLine("Changed value:");
    	SetProperty(value, "B.C.D","changed!");
    	value.Dump();
    }
    public void SetProperty(object target, string property, object setTo)
    {...}
    
    public class A
    {
    	public B B { get; set; } = new B();
    }
    
    public class B
    {
    	public C C { get; set; } = new C();
    }
    
    public class C
    {
    	public string D { get; set; } = "test";
    }
