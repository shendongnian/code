    <ComboBox.ItemTemplate>
        <DataTemplate>
             <TextBlock>
                 <TextBlock.Text>
                      <MultiBinding Converter="{StaticResource MBC}" ConverterParameter="LastNameFirst" >
                          <Binding Path="FirstName"/>
                          <Binding Path="LastName"/>
                      </MultiBinding>
                 </TextBlock.Text>
             </TextBlock>
        </DataTemplate>
     </ComboBox.ItemTemplate>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
         if(parameter == "LastNameFirst")
            return string.Format("{0}, {1}", values[0], values[1]);
         else
            return string.Format("{0}, {1}", values[1], values[0]);
    }
