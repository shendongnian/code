    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            Parse("2009-10-10 09:19:12.124");
            Parse("2009-10-10 12:13:14.852");
            Parse("2009-10-10 13:00:00");
            Parse("2009-10-10 15:23:32.022");
        }
        
        static readonly string ShortFormat = "yyyy-MM-dd HH:mm:ss";
        static readonly string LongFormat = "yyyy-MM-dd HH:mm:ss.fff";
        
        static readonly string[] Formats = { ShortFormat, LongFormat };
        
        static void Parse(string text)
        {
            // Adjust styles as per requirements
            DateTime result = DateTime.ParseExact(text, Formats, 
                                                  CultureInfo.InvariantCulture,
                                                  DateTimeStyles.AssumeUniversal);
            Console.WriteLine(result);
        }
    }
