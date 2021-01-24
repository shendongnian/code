    public class ColoringConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         //is your collection IEnumerable<>? If not, adjust as needed
         var legend = value as IEnumerable<LegendItem>;
         if (legend == null) return value;
         return legend.Select(i => new Run() { Text = i.Text, Foreground = i.Color }).ToArray();
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         throw new NotImplementedException();
      }
    }
