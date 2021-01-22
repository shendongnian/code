    using System;
    using System.Linq;
    
    class Program
    {
    	static event Action foo;
    
    	static void bar() { }
    
    	static void Main()
    	{
    		foo += bar;
    
    		bool contains = foo
    			.GetInvocationList()
    			.Cast<Action>()
    			.Contains(bar);
    	}	
    }
