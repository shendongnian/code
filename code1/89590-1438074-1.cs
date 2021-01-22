    using System;
    
    class Test
    {
        public static string ConvertDateTimeFormat(string input, string inputFormat,
            string outputFormat, IFormatProvider culture)
        {
            DateTime dateTime = DateTime.ParseExact(input, inputFormat, culture);
            return dateTime.ToString(outputFormat, culture);
        }
        
        static void Main()
        {
            Console.WriteLine(ConvertDateTimeFormat("04.09.2009", "dd'.'MM'.'yyyy",
                                                    "yyyy'/'MM'/'dd", null));
        }
    }
