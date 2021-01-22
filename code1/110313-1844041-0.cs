    public class NegatingConverter : IValueConverter
    {
      public object Convert(object value, ...)
      {
        return !((bool)value);
      }
    }
