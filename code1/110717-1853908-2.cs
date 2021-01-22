    using System;
    
    class Example
    {
    	static void Main()
    	{
    		Foo f = new Foo();
    		f.M();
    
    		Foo b = new Bar();
    		b.M();
    	}
    }
    
    class Foo
    {
    	public void M()
    	{
    		Console.WriteLine("Foo.M");
    	}
    }
    
    class Bar : Foo
    {
    	public new void M()
    	{
    		Console.WriteLine("Bar.M");
    	}
    }
