    using System;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		String s = "ab,cd,ef";
    
    		// either a String[]
    		String[] array = s.Split(new Char[] {','});
    		// or a List<String>
    		List<String> list = new List<String>(s.Split(new Char[] { ',' }));
    	}
    }
