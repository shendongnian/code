    public class CheckoutConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int?)
            {
                var COID = value as int?;
    
                if (COID == MainWindow.LocalUser.ID)
                {
                    return Brushes.Green;
                }
                else if ((COID == 0) || (COID == null))
                {
                    return Brushes.Transparent;
                }
                else if (COID != 0)
                {
                    return Brushes.Black;
                }
            }
            return Brushes.Black;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
