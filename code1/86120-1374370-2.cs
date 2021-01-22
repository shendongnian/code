        public class WindowToWindowStyle : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var window = (Window)value;
                var style = (Style)window.FindResource("Window_FixedStyle");
    #if DEBUG
                style = (Style)window.FindResource("Window_Style");
    #endif
                return style;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Binding.DoNothing;
            }
        }
