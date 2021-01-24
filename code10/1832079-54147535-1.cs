    [ValueConversion(typeof(ObservableCollection<string>), typeof(string))]
    class FirstTwoListValuesElemToStringConverter: IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		System.Collections.ObjectModel.ObservableCollection<string> names = ((System.Collections.ObjectModel.ObservableCollection<string>)value);
    		if ((names != null) && (names.Count > 2))
    			return names.FirstOrDefault() + names.ElementAtOrDefault(1);
    		else
    			return System.Windows.DependencyProperty.UnsetValue;
    	}
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
