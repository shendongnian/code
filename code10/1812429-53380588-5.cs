    public class CustomLetterDayConverter : IValueConverter
    {
        static HashSet<DateTime> dict = new HashSet<DateTime>();
        static CustomLetterDayConverter()
        {
            dict.Add(DateTime.Today);
            dict.Add(DateTime.Today.AddDays(1));
            dict.Add(DateTime.Today.AddDays(2));
            dict.Add(DateTime.Today.AddDays(5));
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = null;
            if (dict.Contains((DateTime)value))
                text = null;
            else
                text = "";
            return text;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
