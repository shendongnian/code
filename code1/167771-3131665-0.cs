    public class DegreesConverter: IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<Degree> degrees = (List<Degree>) value;
            return degrees.Any(d => Equals(d.Subject, (Subject)parameter));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    
