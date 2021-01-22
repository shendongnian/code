    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
       public static void Main()
       {
          string pattern = @"^(?<PREFIX>abc_)(?<ID>[0-9])+(?<POSTFIX>_def)$";
          string replacement = "${PREFIX}456${POSTFIX}";
          string input = "abc_123_def";
          string result = Regex.Replace(input, pattern, replacement);
          Console.WriteLine(result);
       }
    }
    // The example displays the following output:
    //      abc_456_def
