    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, string language)
        {
            // Contain your source to target convertion logic. 
        }
        public object ConvertBack(object value, Type targetType, 
            object parameter, string language)
        {
            // Contain your target to source convertion logic.
            // Only needed if using TwoWay or OneWayToSource Binding Mode. 
        }
    }
