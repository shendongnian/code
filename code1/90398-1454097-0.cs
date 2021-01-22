    using System;
    using System.Text.RegularExpressions;
    class Program {
        static void Main(string[] args) {
            Regex regex = new Regex(@"(?:\*(?<client>\w+))|(?:/(?<company>\w+))",RegexOptions.Compiled);
            string input = "*A/AB(M!@12:6?SIMPLE!+5+2";
            foreach (Match match in regex.Matches (input)) {
                if (match.Groups["client"].Success) {
                    Console.WriteLine("Client = {0}", match.Groups["client"].Value);
                } else if (match.Groups["company"].Success) {
                    Console.WriteLine("Company = {0}", match.Groups["company"].Value);
                }
            }
            
            
        }
    }
