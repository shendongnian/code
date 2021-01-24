    [ContentProperty(nameof(Conversions))]
    public class EnumToObjectConverter : IValueConverter
    {
        public Collection<EnumConversion> Conversions { get; } = new Collection<EnumConversion>();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => Conversions.FirstOrDefault(x => Equals(x.Source, value))?.Target;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
