	using System;
	using System.Runtime.InteropServices;
	namespace Foo 
	{
	    class Program
	    {
	        [DllImport("System", EntryPoint = "os_log_create")]
	        private static extern IntPtr os_log_create(string subsystem, string category);
	        [DllImport("Logging", EntryPoint = "Log")]
	        private static extern void Log(IntPtr log, string msg);
	        static void Main(string[] args)
	        {  
	            IntPtr log = os_log_create("some.bundle.id", "SomeCategory");
	            Log(log, "Test!");
	        }
	    }
	}
 
