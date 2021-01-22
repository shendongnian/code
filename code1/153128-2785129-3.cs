    [ValueConversion(typeof(int), typeof(string))]
    public class IntConverter : IValueConverter {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
    		//needs more sanity checks to make sure the value is really int
    		//and that targetType is string
    		return ((int)value).ToString("G");
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
    		//not implemented for now
    		throw new NotImplementedException();
    	}
    }
