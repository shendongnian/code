	public class BoolToBrushConverter : IValueConverter
	{
		public Brush FalseBrush { get; set; }
		public Brush TrueBrush { get; set; }
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == null)
				return FalseBrush;
			else
				return (bool)value ? TrueBrush : FalseBrush;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException("This converter only works for one way binding");
		}
	}
