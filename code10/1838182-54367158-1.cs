    public class ConvertStyle : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            valueType = (YourModel)value
            if (valueType.YourProperty)
            {
                return Application.Current.Resources["portraitStyle"] as Style;
            }
            else
            {
                //other style
            }
        }
    }
