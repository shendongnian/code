    using System;
    using System.Globalization;
    
    public class Test
    {
        static void Main()
        {
            string line1 = "00:00:01.2187500 CA_3";
            string line2 = "00:00:01.5468750 CWAC_1";
            
            TimeSpan sum = ParseLine(line1) + ParseLine(line2);
            Console.WriteLine(sum);
        }
    
        static TimeSpan ParseLine(string line)
        {
            int spaceIndex = line.IndexOf(' ');
            if (spaceIndex != -1)
            {
                line = line.Substring(0, spaceIndex);
            }
            return TimeSpan.ParseExact(line, "hh':'mm':'ss'.'fffffff",
                                       CultureInfo.InvariantCulture);
        }
    }
