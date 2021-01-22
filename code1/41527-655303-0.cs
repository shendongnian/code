    using System;
    using IntFunc = System.Func<int>;
    namespace DelegateAlias
    {
    	class Program
    	{
    		static int foo() { return 314; }
    		static void Main(string[] args)
    		{
			IntFunc f = foo;
    		}
    	}
    }
