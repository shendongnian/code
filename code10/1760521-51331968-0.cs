    <ComboBox.ItemTemplate>
        <DataTemplate>
             <TextBlock>
                 <TextBlock.Text>
                      <MultiBinding Converter="{StaticResource MBC}" ConverterParameter="LastNameFirst" >
                          <Binding Path="."/>
                      </MultiBinding>
                 </TextBlock.Text>
             </TextBlock>
        </DataTemplate>
     </ComboBox.ItemTemplate>
