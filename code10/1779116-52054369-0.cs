    class Program
    {
        private static string AppFormatForParsing = "yyyy-MM-ddTHH:mm:ss.fff"; // e.g. "2018-03-29T09:52:46.544+10:30"
    
        static void Main(string[] args)
        {
            string aDate = "1944-12-12T00:00:00.000";
    
            DateTime? d = TryParseExactDateTime(aDate)?.ToLocalTime();
    
            Console.ReadLine();
        }
    
        public static DateTime? TryParseExactDateTime(string source)
        {
                DateTime parsedDate;
    
                if (DateTime.TryParseExact(source, AppFormatForParsing, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    return parsedDate;
                }
    
                return null;
        }
    }
