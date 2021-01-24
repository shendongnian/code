    public class MarginConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                var height = 0d;
                var chartHeight = (double) values[0];
                var range = (Range<double>) values[1];
    
                if (range.HasData)
                {
                    if (range.Minimum > 0)
                    {
                        // Set labels to bottom
                        height = 0;
                    }
                    else if (range.Maximum < 0)
                    {
                        // Set labels to top
                        height = -chartHeight;
                    }
                    else
                    {
                        var rangeHeight = range.Maximum - range.Minimum;
                        var pointsPerHeight = chartHeight / rangeHeight;
                        height = range.Minimum * pointsPerHeight;
                    }
                }
    
                return new Thickness(25, height, 0, 0);
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
        }
