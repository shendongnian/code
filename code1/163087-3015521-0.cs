        public static class DateTimeStaticExtensions
        {
            private static int GetDesignatorIndex(CultureInfo info)
            {
                if (info.DateTimeFormat
                    .ShortTimePattern.StartsWith("tt"))
                {
                    return 0;
                }
                else if (info.DateTimeFormat
                    .ShortTimePattern.EndsWith("tt"))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
    
            private static string GetFormattedString(int hour, 
                CultureInfo info)
            {
                string designator = (hour > 12 ? 
                    info.DateTimeFormat.PMDesignator : 
                    info.DateTimeFormat.AMDesignator);
                
                if (designator != "")
                {
                    switch (GetDesignatorIndex(info))
                    {
                        case 0:
                            return string.Format("{0} {1}",
                                designator, 
                                (hour > 12 ? 
                                    (hour - 12).ToString() : 
                                    hour.ToString()));
                        case 1:
                            return string.Format("{0} {1}",
                                (hour > 12 ? 
                                    (hour - 12).ToString() :
                                    hour.ToString()), 
                                designator);
                        default:
                            return hour.ToString();
                    }
                }
                else
                {
                    return hour.ToString();
                }
            }
    
            public static string ToTimeString(this DateTime target, 
                CultureInfo info)
            {
                return GetFormattedString(target.Hour, info);
            }
    
            public static string ToTimeString(this DateTime target)
            {
                return GetFormattedString(target.Hour, 
                    CultureInfo.CurrentCulture);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var dt = new DateTime(2010, 6, 10, 6, 0, 0, 0);
    
                CultureInfo[] cultures = 
                    CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach (CultureInfo culture in cultures)
                {
                    Console.WriteLine(
                        "{0}: {1} ({2}, {3}) [Sample AM: {4} / Sample PM: {5}",
                        culture.Name, culture.DateTimeFormat.ShortTimePattern,
                        (culture.DateTimeFormat.AMDesignator == "" ? 
                            "[No AM]": 
                            culture.DateTimeFormat.AMDesignator),
                        (culture.DateTimeFormat.PMDesignator == "" ? 
                            "[No PM]": 
                            culture.DateTimeFormat.PMDesignator),
                        dt.ToTimeString(culture),  // AM sample
                        dt.AddHours(12).ToTimeString(culture) // PM sample
                        );
                }
    
                // pause program execution to review results...
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
