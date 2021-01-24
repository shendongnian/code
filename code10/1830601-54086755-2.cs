    public class ImageConverter : IValueConverter
    {
    	public object Convert(
    		object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		return new BitmapImage(value as Uri);
    	}
    
    	public object ConvertBack(
    		object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		return Binding.DoNothing;
    	}
    }
