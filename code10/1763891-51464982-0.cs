    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var s = System.Convert.ToInt32(value);
            var ret = (s == 3);
            return ret;
        }
