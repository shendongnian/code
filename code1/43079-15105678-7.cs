    public class A
    {
    	public virtual void print()
    	{
    		Console.WriteLine("Parent Method");
    	}
    }
    
    public class B : A
    {
    	public void child()
    	{
    		Console.WriteLine("Child Method");
    	}
    
    	public override void print()
    	{
    		Console.WriteLine("Overriding child method");
    	}
    }
             
