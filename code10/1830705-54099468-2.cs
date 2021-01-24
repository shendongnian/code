    public class IntToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double percent = (double)((int)value) / 100;
            double resultRed = Color.Red.R + percent * (Color.Green.R - Color.Red.R);
            double resultGreen = Color.Red.G + percent * (Color.Green.G - Color.Red.G);
            double resultBlue = Color.Red.B + percent * (Color.Green.B - Color.Red.B);
            return new Color(resultRed, resultGreen, resultBlue);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
