    using System;
    using System.ComponentModel.DataAnnotations;
    					
    public class Program
    {
    	public const string Regex1 = "abc";
    	public const string Regex2 = "xyz";
    	public const string CompositeRegex = Regex1 + "|" + Regex2;
    	
    	public static void Main()
    	{
    		
    		Console.WriteLine(Regex1);
    		Console.WriteLine(Regex2);
    		Console.WriteLine(CompositeRegex);		
    	}
    }
    
    public class TestClass
    {
    	[RegularExpression(Program.Regex1  + "|" + Program.Regex2)]
    	public string TestProperty {get; set;}
    }
