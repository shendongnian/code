    public class PercentageToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double gridWidth = (double)value;
            double percentage = ParsePercentage(parameter);
            return gridWidth * percentage;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        private double ParsePercentage(object parameter)
        {
            // I chose to let it fail if parameter isn't in right format            
            string[] s = ((string)parameter).Split('/');
            double percentage = Double.Parse(s[0]) / Double.Parse(s[1]);
            return percentage;
        }
    }
