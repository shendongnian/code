    public class VerticesConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vertices = value as IEnumerable<Vertex>;
            return vertices != null
                ? new PointCollection(vertices.Select(v => v.Point))
                : null;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
