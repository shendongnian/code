    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		string d = "The @quick @brown^#&*( fox @jumps over @the lazy @dog";
    		Console.WriteLine("Before: {0}", d);
    		d = Regex.Replace(d, "[^\\d\\w\\s]", string.Empty);
    		Console.WriteLine("After : {0}", d);
    	}
    }
