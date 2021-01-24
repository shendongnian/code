    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
      public static void Main()
      {
       string pattern = @"{([A-Za-z0-9\-]+)}" ; 
       string input = "{abc}@{defgh}mner{123}";
       MatchCollection matches = Regex.Matches(input, pattern);
       foreach (Match match in matches)
       {
         Console.WriteLine(match.Groups[1].Value);
       }
       Console.WriteLine();
      }
    }
   
