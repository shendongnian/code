    public class HeaderType1BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var s = 0;
            try{ s = (int)value; }catch(Exception e){ return false; }
            return s != 3;
        }
    }
