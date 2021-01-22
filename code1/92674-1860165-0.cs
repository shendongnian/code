    public class StyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Style style1 = App.Current.FindResource("RowStyle1") as Style;
            Style style2 = App.Current.FindResource("RowStyle2") as Style;
            List<object> items = parameter as List<object>;
            if (items[0] == value)
            {
                return style1;
            }
            
            return style2;
        }
    }
