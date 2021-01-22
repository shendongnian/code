    using System;
    using System.IO;
    
    class Test {
    	static void Main ()
    	{
    		//string [] str = new string[] {@"c:\program files\vim\vim72", @"c:\progra~1\vim\vim72"};
    		string [] str = new string[] {@"c:\program files\Refere~1\microsoft", @"c:\progra~1\Refere~1\microsoft"};
    		foreach (string s in str) {
    			Console.WriteLine (Path.GetFullPath (s));
    		}
    	}
    }
