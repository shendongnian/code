    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		string text = "A Foobar is cool stuff, as we can see in Figure 1.1:\r\n\r\n  Figure 1.1  This is a Foobar\r\n\r\nMore text here.";
            text = Regex.Replace(text, "^ +(Figure[^\r\n]*)", "##### _$1_", RegexOptions.Multiline);
            Console.WriteLine(text);
    	}
    }
