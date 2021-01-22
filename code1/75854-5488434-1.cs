    public class EmptyStringToNullConverter : IValueConverter
	{
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value == null || string.IsNullOrEmpty(value.ToString())
				? null
				: value;
		}
		#endregion
	}
