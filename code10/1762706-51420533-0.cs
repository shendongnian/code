    public class DateFormatConverter : IsoDateTimeConverter
        {
            public DateFormatConverter(string format)
            {
                DateTimeFormat = format;
                Culture = new CultureInfo("nl-BE"); //use this to have CET time !
            }
        }
