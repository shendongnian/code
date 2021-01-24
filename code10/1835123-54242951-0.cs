    public class DistinctBrushMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Distinct().Count() == 1)
            {
                return Brushes.Orange; //Brush you want for highlight 
            }
            return null; //Or your default Brush
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
