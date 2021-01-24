    public class BazToString : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var bazName = (string)values[0];
            var bars = (IEnumerable<Bar>)values[1];
            string s = "Baz is " + bazName + " ";
            foreach (Bar bar in bars)
            {
                s += "with a Bar " + bar.Name + " ";
            }
            return s;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
