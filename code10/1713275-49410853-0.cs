    class MultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ItemsControl ic = (ItemsControl)values[0];
            object item = values[1];
            return ic.Items.IndexOf(item) == ic.Items.Count - 1 ? Visibility.Collapsed : Visibility.Visible;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
