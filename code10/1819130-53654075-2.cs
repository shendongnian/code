    public class Interface1Indexer : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		return (value as ITestCaseInterface1)[parameter as string];
    	}
    
    	public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException("one way converter");
    	}
    }
    <TextBlock Text="{Binding Converter={StaticResource interface1Indexer}, ConverterParameter='abc'" />
