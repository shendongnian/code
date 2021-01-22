    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main(string[] args)
        {
            string input = "10/13/2009 12:00:00 AM";
            string inputFormat = "MM/dd/yyyy HH:mm:ss tt";
            string outputFormat = "yyyyMMdd";
            DateTime dt = DateTime.ParseExact(input, inputFormat, 
                                              CultureInfo.InvariantCulture);
            string output = dt.ToString(outputFormat, CultureInfo.InvariantCulture);
            Console.WriteLine(output);
        }
    }
