    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var regex = new Regex(@"(\{(?<var>\w*)\})+", RegexOptions.IgnoreCase);
                var text = "Hello this is a {Testvar}... and we have more {Tagvar} in this string {Endvar}.";
                var matches = regex.Matches(text);
    
                foreach (Match match in matches)
                {
                    var variable = match.Groups["var"];
                    Console.WriteLine($"Found {variable.Value} from position {variable.Index} to {variable.Index + variable.Length}");
                }
            }        
        }
    }
