    public class ToolTipConverter : IValueConverter
    {
         public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UIElement tip = null;
            if (value != null)
            {
                // Value is the data context
                Type t = value.GetType();
                string fancyName = "Unknown (" + t.ToString() + ")";
                // Can use IsInstanceOf, strings, you name it to do this part...
                if (t.ToString().Contains("Person"))
                {
                    fancyName = "My custom person type";
                };
                // Could create any visual tree here for the tooltip child
                TextBlock tb = new TextBlock
                {
                    Text = fancyName
                };
                tip = tb;
            }
            return tip;
        }
        public object ConvertBack(object o, Type t, object o2, CultureInfo ci)
        {
            return null;
        }
    }
