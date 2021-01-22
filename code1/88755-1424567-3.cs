    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
	namespace TestGlobalMethod
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            "MyUtilMethod".Call();
	            Console.ReadKey();
	        }
	    }
	    /// <summary>
	    /// Reduces the amount of code for global call
	    /// </summary>
	    public static class GlobalExtensionMethods 
	    {
	        public static void Call(this string GlobalMethodName)
	        {
	            Assembly.Load("globalmethods")
	                .GetLoadedModules()[0].GetMethod(GlobalMethodName)
	                    .Invoke(null,null);
	        }
	    }
	}
