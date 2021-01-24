    <ItemsControl ItemsSource="{Binding ColOfCol}" AlternationCount="2147483647">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <ItemsControl ItemsSource="{Binding }" AlternationCount="2147483647">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBlock>
                                <TextBlock.Text>
                                    <MultiBinding Converter="{StaticResource multivalcnv}">
                                        <Binding Path='(ItemsControl.AlternationIndex)' RelativeSource="{RelativeSource AncestorType=ContentPresenter, AncestorLevel=2}"></Binding>
                                        <Binding Path='(ItemsControl.AlternationIndex)' RelativeSource="{RelativeSource AncestorType=ContentPresenter, AncestorLevel=1}"></Binding>
                                    </MultiBinding>
                                </TextBlock.Text>
                            </TextBlock>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
---
    public class MultValConverter : IMultiValueConverter
    {
    	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    	{
    		if (values.Length == 2)
    		{
    			//return (values[0], values[1]); //For the ViewModel
    			return (values[0], values[1]).ToString(); //For the UI example
    			}
    		else
    			return Binding.DoNothing;
    	}
    
    	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException("It's a one way converter.");
    	}
    }
