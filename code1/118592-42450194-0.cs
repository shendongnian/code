    void Main()
    {
    	BaseClass demo = new DClass(3.6);
    }
    
    public abstract class BaseClass
    {
    	public abstract double MyPop{ get; }
    }
    
    public class DClass : BaseClass
    {
    	public override double MyPop { get; }
    	public DClass(double myPop) { MyPop = myPop;}
    }
