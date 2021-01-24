    <telerik:GridViewDataColumn Header="Country" DataMemberBinding="{Binding}">
         <telerik:GridViewDataColumn.CellTemplate>
           <DataTemplate>
               <StackPanel Orientation="Horizontal">
                  <TextBlock Text="{Binding Converter={StaticResource convResName}, ConverterParameter={StaticResource yourDictAsResource}}" />
               </StackPanel>
           </DataTemplate>
       </telerik:GridViewDataColumn.CellTemplate>
    </telerik:GridViewDataColumn>
    
    public class ValueConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		var person = value as Person;
    		if (person==null)
    		{
    			return null;
    		}
    		var dict = parameter as Dictionary<string, string>;
    		if (string.IsNullOrWhiteSpace(person.Country))
    		{
    			try
    			{
    				person.Country = dict[person.Code];
    			}
    			catch (KeyNotFoundException exc)
    			{
    				//handle exc
    			}
    		}
    		return person.Country;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
