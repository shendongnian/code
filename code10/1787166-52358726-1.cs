    public class DurationFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, string language)
        {
            string formatString = parameter as string;
            if (formatString == "hoursBox")
            {
                return ((TimeSpan)value).Hours.ToString();
            }
            else if (formatString == "minutesBox")
            {
                return ((TimeSpan)value).Minutes.ToString();
            }
            else
            {
                return ((TimeSpan)value).Seconds.ToString();
            }
        }
 
        public object ConvertBack(object value, Type targetType, 
            object parameter, string language)
        {
            string formatString = parameter as string;
            if (formatString == "hoursBox")
            {
                return TimeSpan.FromHours(ConvertToInt32(((string)value)));//Here you get the hours value sent from textbox to backend.
            }
            else if (formatString == "minutesBox")
            {
                return TimeSpan.FromMinutes(ConvertToInt32(((string)value)));//Here you get the minutes value sent from textbox to backend.
            }
            else
            {
                return TimeSpan.FromSeconds(ConvertToInt32(((string)value)));//Here you get the seconds value sent from textbox to backend.
            }
        }
    }
