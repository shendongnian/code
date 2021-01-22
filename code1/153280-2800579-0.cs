    public class EnumToVisibilityConvertor : IValueConverter
    {
        private bool chk;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((value != null) && (value is BreakLevel) && (targetType == typeof(Visibility)))
            {
              chk =   ((((BreakLevel) value) == (BreakLevel) Enum.Parse(typeof (BreakLevel), parameter.ToString(), true)));
              return (chk==true) ? Visibility.Visible : Visibility.Collapsed;
            }
            throw new InvalidOperationException("Invalid converter usage.");
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
                      
          <Border CornerRadius="4" BorderThickness="1"  BorderBrush="#DAE0E5"  
    Visibility="{Binding Path=Level, Converter={StaticResource enumToVisibilityConvertor},ConverterParameter=Fatal}" >
