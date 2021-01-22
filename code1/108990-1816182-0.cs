    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        public static void Main()
        {
            string html = @"        function strengthObject() {
                    this.base=""168"";
                    this.effective=""594"";
                    this.block=""29"";
                    this.attack=""1168"";";
    
            string regex = @"this.effective=""(\d+)""";
    
            Match match = Regex.Match(html, regex);
            if (match.Success)
            {
                int effective = int.Parse(match.Groups[1].Value);
                Console.WriteLine("Effective = " + effective);
                // etc..
            }
            else
            {
                // Handle failure...
            }
        }
    }
