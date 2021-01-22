    interface IFinal
    {
    	string YourName();
    }
    
    abstract class FinalBase : IFinal
    {
    	public virtual string YourName() { return string.Empty; }
    }
    
    class A : FinalBase
    {
    	public override string YourName()
    	{
    		return "A";
    	}
    }
    
    class B : FinalBase
    {
    	public override string YourName()
    	{
    		return "B";
    	}
    }
    
    class C : A
    {
    	public override string YourName()
    	{
    		return "C";
    	}
    }
    new A().YourName(); // A
    new B().YourName(); // B
    IFinal b = new B();
    b.YourName(); // B
    FinalBase b = new C();
    b.YourName(); // C
