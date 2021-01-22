    using System;
    using System.Runtime.InteropServices;
    
    public class MyClass
    {
    	public static void Main()
    	{
    		Int32 a = 10;
    		Console.WriteLine(Marshal.SizeOf(a));
    		Console.ReadLine();
    	}
    }
