    public class StateToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			TabViewModelState state = (TabViewModelState) value;
            return state == TabViewModelState.True;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool result = (bool) value;
            return result ? TabViewModelState.True : TabViewModelState.False;
		}
	}
