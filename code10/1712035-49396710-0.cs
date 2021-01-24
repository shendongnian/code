    public class EnumSelectedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null) return false;
            TestType vmType = (TestType) value;
            TestType viewType = (TestType) parameter;
            return vmType == viewType;
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null) return false;
            
            bool isSelected = (bool) value;
            if (!isSelected) return false;
            TestType vTestType = (TestType) parameter;
            return vTestType;
        }
    }
