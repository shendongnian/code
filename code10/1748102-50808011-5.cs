    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		var start = @"a-zA-Z\d#@";
    		var then = start + @"\-\. ";
    		var regex = new Regex($@"[{start}][{then}]{{1,149}}");
    		Test(regex);
    	}
    
    	public static void Test(Regex regex)
    	{
    		const int numTests = 10;
    		const int stringLength = 150;
    		var rand = new Random();
    		var start = new string[]{"1", "a", "#", "@", };
    		var then = new string[]{"1", "a", "#", "@", "-", ".", " "};
    		for (var i = 0; i < numTests; ++i)
    		{
    			var builder = new StringBuilder(start[0]);
    			for (var j = 1; j < stringLength; ++j)
    			{
    				var r = rand.Next() % then.Length;
    				builder.Append(then[r]);
    			}
    
    			var test = builder.ToString();
    			Console.WriteLine($"{test} {regex.IsMatch(test)}");
    		}
    	}
    }
