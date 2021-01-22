    <Object Value="{Binding Path=ComplexValueObject, Converter={StaticResource ComplexValueConverter}, ConverterParameter=PropertyOne}" /> 
    
    public class ComplexValueConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        ComplexValue cv = value as ComplexValue;
        string propName = parameter as string;
        switch (propName)
        {
          case "PropertyOne":
            return cv.PropertyOne;
          case "PropertyTwo":
            return cv.PropertyTwo;
          default:
            throw new Exception();
        }
      }
        
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
