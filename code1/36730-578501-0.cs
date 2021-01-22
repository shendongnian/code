    using System;
    using System.Runtime.Remoting;
    
    class Program
    {
    	static void Main()
    	{
    		ObjectHandle o = Activator.CreateInstance("mscorlib.dll", "System.Int32");
    
    		Int32 i = (Int32)o.Unwrap();
    	}
    }
