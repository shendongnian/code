	public class BoolToContentConverter : IValueConverter
	{
		public BoolToContentConverter()
		{
			TrueContent = "True Tool Tip";
			FalseContent = "False Tool Tip";
			NullContent = "No Value";
		}
		public object TrueContent { get; set; }
		public object FalseContent { get; set; }
		public object NullContent { get; set; }
		public object Convert(object value, Type targetType, 
			   object parameter, CultureInfo culture)
		{
			if (value == null)
				return NullContent;
			bool boolValue = true;
			bool isBool = true;
			try
			{
				boolValue = (bool) value;
			}
			catch
			{
				isBool = false;
			}
			if (!isBool)
				return NullContent;
			return boolValue ? TrueContent : FalseContent;
		}
		public object ConvertBack(object value, Type targetType, 
			   object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	} 
