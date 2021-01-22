    using System;
    
    class Foo { }
    
    class Test
    {
    	static void Main()
    	{
    		Foo foo = new Foo();
    		Console.WriteLine(foo.GetType().Name);
    	}
    }
