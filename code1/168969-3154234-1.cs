    public class PropertyValueConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return
                from p in value.GetType().GetProperties()
                where p.IsDefined(typeof(IsImportant), false)
                select new PropertyValue(p, value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
