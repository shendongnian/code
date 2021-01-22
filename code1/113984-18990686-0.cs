        static void Main(string[] args)
        {
            foreach (var cultureInfo in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
            {
                string longDateWithoutDayOfWeek = null;
                foreach (var pattern in cultureInfo.DateTimeFormat.GetAllDateTimePatterns('D'))
                {
                    if (!pattern.Contains("ddd"))
                    {
                        longDateWithoutDayOfWeek = pattern;
                        break;
                    }
                }
                bool isFallbackRequired = string.IsNullOrEmpty(longDateWithoutDayOfWeek);
                if (isFallbackRequired)
                {
                    longDateWithoutDayOfWeek = cultureInfo.DateTimeFormat.ShortDatePattern;
                }
                System.Console.WriteLine("{0} - {1} {2}", cultureInfo.Name, longDateWithoutDayOfWeek, (isFallbackRequired) ? " (short)" : string.Empty);
            }
        }
