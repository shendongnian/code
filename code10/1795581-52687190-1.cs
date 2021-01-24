    public class VerticesConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vertices = value as IEnumerable<Vertex>;
            if (vertices == null)
            {
                return null;
            }
            return new PointCollection(vertices.Select(v => v.Point));
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
