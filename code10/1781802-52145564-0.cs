    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            Console.WriteLine(ParseWithOrdinals("10th Mar 2015"));
            Console.WriteLine(ParseWithOrdinals("1st Oct 2018"));
        }
        
        private static DateTime ParseWithOrdinals(string input) =>
            DateTime.ParseExact(
                RemoveOrdinals(input), // Text to parse
                "d MMM yyyy",          // Format of text
                CultureInfo.InvariantCulture); // Expect English month names, Gregorian calendar
                     
        
        // From https://stackoverflow.com/questions/17710561
        private static string RemoveOrdinals(string input) =>
            input
                .Replace("0th", "0")
                .Replace("1st", "1")
                .Replace("2nd", "2")
                .Replace("3rd", "3")
                .Replace("11th", "11") // Need to handle these separately...
                .Replace("12th", "12")
                .Replace("13th", "13")
                .Replace("4th", "4")
                .Replace("5th", "5")
                .Replace("6th", "6")
                .Replace("7th", "7")
                .Replace("8th", "8")
                .Replace("9th", "9");
    }
