    public class BlankZeroConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
            {
                if (value == null)
                    return null;
    
                if (value is double)
                {
                    if ((double)value == 0)
                    {
                        return string.Empty;
                    }
                    else
                        return value.ToString();
    
                }
                return string.Empty;
            }
       }
