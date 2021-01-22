    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if(value != null && value.GetType().Equals(typeof(bool)))
                {
                    return (bool)value ? "Complete" : "Active";                
                }
                return null;
            }
