    using System;
    using System.Text.RegularExpressions;
    public class MyClass
    {
    	public static void Main()
    	{
    		string domainUser = Regex.Replace("domain\\user",".*\\\\(.*)", "$1",RegexOptions.None);
    		Console.WriteLine(domainUser);	
    		
    	}
    
    }
