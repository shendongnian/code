    public class MyCustomControlConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            var control = new MyCustomControl();
            control.SetBinding(MyCustomControl.TextProperty,
                new Binding("Text") { Source = value });
            control.SetBinding(MyCustomControl.ParameterProperty,
                new Binding("Parameters") { Source = value });
            return control;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
