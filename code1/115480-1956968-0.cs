    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Reflection;
    
    public class MyClass
    {
    	public static void Main()
    	{
    		object xlApp  = Marshal.GetActiveObject("Excel.Application");
    		Type t = xlApp.GetType();
    		
    		t.InvokeMember("Quit", BindingFlags.InvokeMethod, null, xlApp, null);
    	
    	}
    }
