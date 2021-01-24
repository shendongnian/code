    public class TypeToSubTypesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) return null;
            if (values[0] == null || values[0] == DependencyProperty.UnsetValue) return null;
            var type = values[0].ToString();
            if (values[1] == null || values[1] == DependencyProperty.UnsetValue) return null;
            var subTypeList = values[1] as Dictionary<string, List<string>>;
            if (subTypeList == null) return null;
            return subTypeList[type];
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
