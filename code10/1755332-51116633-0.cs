    public class BrandColorConverter : IValueConverter
    {
        public Dictionary<String, Brush> Brands = new Dictionary<string, Brush>()
        {
            { "brand1", Brushes.Red },
            { "brand2", Brushes.Blue }
        };
        public object Convert(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
        {
            if (!(value is BusService))
                return Binding.DoNothing;
            var busService = (BusService)value;
            if (!Brands.ContainsKey(busService.BrandName))
                return Binding.DoNothing;
            return Brands[busService.BrandName];
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
