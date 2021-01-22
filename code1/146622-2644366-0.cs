    public class Foo
    {
    	public virtual void Baz()
    	{
    		Console.WriteLine("Foo.Baz");
    	}
    }
    
    public class Bar : Foo
    {
    	public override void Baz()
    	{
    		Console.WriteLine("Bar.Baz");
    	}
    	
    	public override void Test()
    	{
    		base.Baz();
    		Baz();
    	}
    }
