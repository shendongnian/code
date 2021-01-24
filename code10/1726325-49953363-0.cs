    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            Test("AR");
            Test("99/99/9999 to 99/99/9999");
            Test("15/02/2018 to 23/04/2018");
        }
    
        static void Test(string text)
        {
            var result = TryParseDates(text, out var from, out var to);
            Console.WriteLine(result 
                ? $"{text}: match! From={from:yyyy-MM-dd}; To={to:yyyy-MM-dd}"
                : $"{text}: no match");
        }    
        
        static readonly Regex dateToDatePattern = new Regex(@"^(\d{2}/\d{2}/\d{4}) to (\d{2}/\d{2}/\d{4})$");
        
        static bool TryParseDates(string text, out DateTime from, out DateTime to)
        {
            var match = dateToDatePattern.Match(text);
            if (match.Success)
            {
                // Don't assign values to the out parameters until we know they're
                // both valid.
                if (DateTime.TryParseExact(match.Groups[1].Value, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempFrom)
                    &&
                    DateTime.TryParseExact(match.Groups[2].Value, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempTo))
                {
                    from = tempFrom;
                    to = tempTo;
                    return true;
                }
            }
            // Either the regex or the parsing failed. Either way, set
            // the out parameters and return false.
            from = default(DateTime);
            to = default(DateTime);
            return false;
        }
    }
