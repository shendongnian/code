    [ValueConversion(typeof(DateTime), typeof(Visibility))]
    public class CurrentDateVisibilityConverter : IValueConverter
    {
        public Visibility CurrentDateVisibility { get; set; } = Visibility.Visible;
        public Visibility PastDateVisibility { get; set; } = Visibility.Collapsed;
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime inputDate= (DateTime)value;
                DateTime nowDate = DateTime.Now;
                if (inputDate.Date == nowDate.Date)
                {
                    return CurrentDateVisibility;
                }
                else
                {
                    return PastDateVisibility;
                }
            }
            else
            {
                return PastDateVisibility;
            }
    
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    
    }
