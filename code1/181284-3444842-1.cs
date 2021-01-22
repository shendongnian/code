    public class BoolToImage : IValueConverter 
    {
        public Image TrueImage { get; set; }
        public Image FalseImage { get; set; }
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool))
            {
                return null;
            }
    
            bool b = (bool)value;
            if (b)
            {
                return this.TrueImage;
            }
            else
            {
                return this.FalseImage;
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
