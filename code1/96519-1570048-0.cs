    public class DebugConverter : IValueConverter {
      public object Convert(object value,
         Type targetType, object parameter,
         System.Globalization.CultureInfo culture) {
         return value; //set the breakpoint here
      }
      public object ConvertBack(object value,
       Type targetType,
       object parameter,
       System.Globalization.CultureInfo culture) {
         return value;
      }
