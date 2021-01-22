     using System.Text.RegularExpressions;
     public static void FindErrorInText(string input)
     {
       Regex rgx = new Regex("ERROR en linea \d*", RegexOptions.IgnoreCase);
       MatchCollection matches = rgx.Matches(input);
       if (matches.Count > 0)
       {
         Console.WriteLine("{0} ({1} matches):", input, matches.Count);
         foreach (Match match in matches)
            Console.WriteLine("   " + match.Value);
       }
     }
