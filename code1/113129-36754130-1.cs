    using System;
    using System.Globalization;
    using System.Windows.Data;
    namespace MyConverters
    {
        [ValueConversion(typeof(DateTime), typeof(string))]
        public class RelativeTimeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                DateTime Date = (DateTime)value;
                if (Date == null) return "never";
                return Utility.RelativeTime(Date);
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
        }
    }
