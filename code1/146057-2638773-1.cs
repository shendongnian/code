    public class FlagsToBoolConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			Options selected = (Options)values[0];
			Options current = (Options)values[1];
			return ((selected & current) == current);
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
