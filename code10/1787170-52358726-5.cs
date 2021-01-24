    public class DurationFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, string language)
        {
            string formatString = parameter as string;
            if (formatString == "hoursBox")
            {
                string rValue = ((TimeSpan)value).Hours.ToString();
                DurationValues.Hours=rValue;
                return rValue;
            }
            else if (formatString == "minutesBox")
            {
                string rValue = ((TimeSpan)value).Minutes.ToString();
                DurationValues.Minutes=rValue;
                return rValue;
            }
            else
            {
                string rValue = ((TimeSpan)value).Seconds.ToString();
                DurationValues.Seconds=rValue;
                return rValue;
            }
        }
 
        public object ConvertBack(object value, Type targetType, 
            object parameter, string language)
        {
            string formatString = parameter as string;
            if (formatString == "hoursBox")
            {
                DurationValues.Hours = (string)value;
                var ts = new TimeSpan (DurationValues.Hours,DurationValues.Minutes,DurationValues.Seconds);
                return ts;
            }
            else if (formatString == "minutesBox")
            {
                DurationValues.Minutes = (string)value;
                var ts = new TimeSpan (DurationValues.Hours,DurationValues.Minutes,DurationValues.Seconds);
                return ts;
            }
            else
            {
                DurationValues.Seconds = (string)value;
                var ts = new TimeSpan (DurationValues.Hours,DurationValues.Minutes,DurationValues.Seconds);
                return ts;
            }
        }
    }
