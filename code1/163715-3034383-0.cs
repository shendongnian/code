    public class BoolToStyleConverter : IValueConverter
	{
		public Style TrueStyle{ get; set; }
		public Style FalseStyle{ get; set; }
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return ((bool)value) ? TrueStyle : FalseStyle;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
