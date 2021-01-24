    <Grid>
        <Grid.Resources>
            <local:BoolToVisConverter x:Key="btoviscnv"/>
        </Grid.Resources>
        <TextBlock Text="text3" Visibility="{Binding MyBoolean, Converter={StaticResource btoviscnv}, ConverterParameter='not'}"/>
        <TextBlock Visibility="{Binding MyBoolean, Converter={StaticResource btoviscnv}}">
            <Run>text1</Run>
            <Run Foreground="#FF1372D3" Text="{Binding MyBinding}"/>
            <Run>text2</Run>
        </TextBlock>
    </Grid>
    public class BoolToVisConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		var bvalue = (bool)value;
    		if ((parameter as string)?.Equals("not") ?? false)
    		{
    			bvalue = !bvalue;
    		}
    		return bvalue ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException("It's one way converter");
    	}
    }
