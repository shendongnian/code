    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    class Program
    {
    	static event Action foo = delegate { };
    
    	static void Main()
    	{
    		foo += bar;
    
    		var actions 
    			= foo.GetInvocationList().Cast<Action>().ToList<Action>().Contains(bar);
            // now actions contains a List<Action> with any references to "bar"
    	}
    
    	static void bar() { }
    }
