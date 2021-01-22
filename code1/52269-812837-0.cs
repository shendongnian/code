    using System;
    
    class Program
    {
    	static void Main()
    	{
    		// prints "zero"
    		Console.WriteLine((Foo)0);
    		// prints "1"
    		Console.WriteLine((int)Foo.one);
    	}
    }
    
    enum Foo { zero, one, two };
