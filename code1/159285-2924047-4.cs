    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null)
                {
                    if (value.GetType().Equals(typeof(Boolean)))
                    {
                        return (bool)value ? "Complete" : "Active";
                    }
                    if (value.GetType().Equals(typeof(String)))
                    {
                        return value as string;
                    }
                }
                return null;
            }
