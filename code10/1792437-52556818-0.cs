    public class BoolVisiblityInverseConverter: IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(bool))
            {
                throw new ArgumentException("BoolVisiblityInverseConverter can only accept a bool");
            }
            var val = (bool)value;
            return val ? Visibility.Collapsed : Visibility.Visible;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
