    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string address = "My current address is #6789, Baker Avenue (CB)";
    		Regex regex = new Regex("#.+\\(");
    		address = regex.Replace(address, "#574, Tomson Street (");
    		Console.WriteLine(address);
    	}
    }
