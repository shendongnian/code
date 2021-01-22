        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var alterationCount = (int)values[0];
            var itemCount = (int)values[1];
            if (itemCount > 1)
            {
                return alterationCount == (itemCount - 1) ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Collapsed;
        }
