    using System;
    using System.IO;
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		Thingy t = DoStuff;
    		var mi = t.Method;
    	}
    	private delegate void Thingy(object sender, EventArgs e);
    	private static void DoStuff(object sender, EventArgs e)
    	{
    
    	}
    }
