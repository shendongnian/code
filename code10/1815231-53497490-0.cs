    public class CodeStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DataGridRow row;
            if (value is DataGridRow)
            {
                row = value as DataGridRow;
                if (row.Code == "I")
                {
                    return Brushes.Red;
                }
                else if (row.Code == "E")
                {
                    return Brushes.Blue;
                }
            }
            return Brushes.Black;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
