    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
    	public static void Main()
    	{
    
            string pattern = @"[^,]+|,""(.*?)"",";
            string input = @"something not qualified,""12"" x 12"" something qualified, becuase it has a comma"",this one is not qualified and needs no fixing a 12"" x 12""";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
    			if(m.Groups[1].Success)
    				Console.WriteLine("'{0}'", m.Groups[1].Value);
    			else
                	Console.WriteLine("'{0}'", m.Value);
            }
    	}
    }
