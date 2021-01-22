    public class RowIndexConverter : IValueConverter
    {
        public object Convert( object value, Type targetType,
                               object parameter, CultureInfo culture )
        {
            var row = (IDictionary<string, object>) value;
            var key = (string) parameter;
            return row.Keys.Contains( key ) ? row[ key ] : null;
        }
        public object ConvertBack( object value, Type targetType,
                                   object parameter, CultureInfo culture )
        {
            throw new NotImplementedException( );
        }
    }
