    using System;
    using System.Diagnostics;
    
    namespace RunMailTo
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Process.Start("mailto://name@example.com");
    		}
    	}
    }
