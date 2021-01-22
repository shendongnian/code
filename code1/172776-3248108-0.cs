    namespace ConsoleApplication
    {
        using System;
        using System.Text.RegularExpressions;
        
        static class Program
        {
            static void Main()
            {
                var expression = new Regex(
                    @"Customer's first Name is (?<FirstName>[^,]+), " +
                    @"his last name is (?<LastName>[^,]+), " +
                    @"his company name is (?<CompanyName>[^,]+), " +
                    @"he has a balance of (?<Balance>[0-9]+) dollars\. " +
                    @"His spending rate is (?<SpendingRate>[^%]+)%");
    
                var line = @"Customer's first Name is john, his last name is glueck, his company name is abc def technolgies llc, he has a balance of 60 dollars. His spending rate is +3.45%";
    
                var match = expression.Match(line);
    
                Console.WriteLine("First name......{0}", match.Groups["FirstName"]);
                Console.WriteLine("Last name.......{0}", match.Groups["LastName"]);
                Console.WriteLine("Balance.........{0}", match.Groups["Balance"]);
                Console.WriteLine("Spending rate...{0}", match.Groups["SpendingRate"]);
    
                Console.ReadLine();
            }
        }
    }
