    interface IFinal
    {
    	string YourName();
    }
    
    class A: IFinal
    {
    	public virtual string YourName() { return "Amit"; }
    }
    
    class B: IFinal
    {
    	public virtual string YourName() { return "Joy"; }
    }
