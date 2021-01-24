      public class RowStyleConverter : IValueConverter
        {
            int counter = 0;
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {   
                if (counter % 2 == 1)
                {   counter++;
                    return new SolidColorBrush(Color.FromArgb(255, 233, 252, 251));                    
                }
                else
                {   counter++;
                    return new SolidColorBrush(Color.FromArgb(255, 220, 239, 238));
                }               
    
            }      
    
        }
