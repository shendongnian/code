    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"((.*Marken\>)|(.*?))(?'target'.+)";
            string input = @"Pferde>Bandagen und Gamaschen>Glocken und Fesselschutz,Marken>Waldhausen,Pferde>Bandagen und Gamaschen
    Pferde>Sattelzubehör>Zubehör,Marken>Waldhausen,Pferde>Sattelzubehör
    Pferde>Sättel,Marken>Wintec
    Marken>Wintec
    Reiter>Reithelme und Sicherheit>Reflexartikel,Pferde>Bandagen und Gamaschen>Glocken und Fesselschutz,Marken>Waldhausen,Reiter>Reithelme und Sicherheit,Pferde>Bandagen und Gamaschen
    Pferde>Trensen und Zubehör";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Groups["target"].Value.Trim(), m.Index);
            }
        }
    }
