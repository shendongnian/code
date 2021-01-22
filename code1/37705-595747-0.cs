    using System;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		foo(new List<int>());
    	}
    
    	static void foo(IEnumerable<int> list) { }
    }
