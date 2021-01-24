    public class HeightToFontSizeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double height = DependencyService.Get<IScreenDimensions>().GetScreenHeight();
			return (double) height * (double) parameter;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// no need to convert anything back
			throw new NotImplementedException();
		}
	}
