    public class FlagToBoolConverter : IMultiValueConverter
    {
        private YourFlagEnum selection;
        private YourFlagEnum mask;
        public static int InstanceCount = 0;
        public FlagToBoolConverter()
        {
            InstanceCount++;
        }
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            mask = (YourFlagEnum ) values[1];
            selection = (YourFlagEnum ) values[0];
            return (mask & selection) != 0;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.Equals(true))
            {
                selection |= mask;
            }
            else
            {
                selection &= ~mask;
            }
            object[] o = new object[2];
            o[0] = selection;
            o[1] = mask;
            return o;
        }
    }
  
  
