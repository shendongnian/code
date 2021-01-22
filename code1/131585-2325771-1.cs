    public class IsEnabledConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Implement your logic here, and return true/false accordingly
            return true;
        }
        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
