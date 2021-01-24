    public class MultiplyConverter : MarkupExtension, IValueConverter
    {
        public double Multiplier { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double bound = System.Convert.ToDouble(value);
            return bound * Multiplier;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
