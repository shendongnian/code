    public class myConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush clr;
            if (int.Parse(value.ToString()) >= 80)
                clr = new SolidColorBrush(Colors.Green);
            else if (int.Parse(value.ToString()) >= 40)
                clr = new SolidColorBrush(Colors.Orange);
            else if (int.Parse(value.ToString()) >= 0)
                clr = new SolidColorBrush(Colors.Red);
            else
                clr = new SolidColorBrush(Colors.White);
            return clr;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
