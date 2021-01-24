    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		AChildClass instance = new AChildClass()
    		{
    			DoSomethingExtra = () => Console.WriteLine("print this also")
    		};
    		instance.DoAThing();
    	}
    }
    
    public class ABaseClass
    {
    	public Action DoSomethingExtra;
    	public virtual void DoAThing()
    	{
    		DoSomethingExtra();
    		Console.WriteLine("print this base");
    	}
    }
    
    public class AChildClass : ABaseClass
    {
    	public override void DoAThing()
    	{
    		Console.WriteLine("child override");
    		base.DoAThing();
    	}
    }
