    class LinearConverter : IValueConverter
    {
        public double Scale { get; set; }
        public double Offset { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: exception handling
            return System.Convert.ToDouble(value) * Scale + Offset;
        }
        // ConvertBack just throws a NotImplementedException
    }
