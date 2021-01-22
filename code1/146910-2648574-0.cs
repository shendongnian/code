    using System;
    using System.Runtime.InteropServices;
    
    class Example
    {
    	static void Main()
    	{
    		IntPtr pointer = Marshal.AllocHGlobal(1024);
    	}
    }
