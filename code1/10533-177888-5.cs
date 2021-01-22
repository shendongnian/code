    class PersonNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
                return values[0].ToString() + " " + values[1].ToString();
        }
        public object ConvertBack(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
                throw new NotImplementedException();
        }
    }
