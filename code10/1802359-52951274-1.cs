    <ComboBox>
        <ComboBox.SelectedItem>
            <Binding Path="PropertyName">
                <Binding.Converter>
                    <local:Converter />
                </Binding.Converter>
            </Binding>
        </ComboBox.SelectedItem>
        <ComboBox.ItemsSource>
            <CompositeCollection xmlns:sys="clr-namespace:System;assembly=mscorlib">
                <sys:Int16 />
                <CollectionContainer Collection="{Binding Source={StaticResource items}}"/>
            </CompositeCollection>
        </ComboBox.ItemsSource>
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Name, FallbackValue='(None)'}"/>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
