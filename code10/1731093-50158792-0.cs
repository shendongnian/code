    <ComboBox>
        <ComboBox.Resources>
            <CollectionViewSource x:Key="ComboCollection" Source="{Binding Path=mySelectedItem.Stammkinder}" />
            <!-- Define a DataTemplate here -->
            <DataTemplate DataType="{x:Type your_namespace:ChildPartner}">
                <TextBlock Text="{Binding PartnerID}"/>
            </DataTemplate>
        </ComboBox.Resources>
        <ComboBox.ItemsSource>
            <CompositeCollection>
                <ComboBoxItem Content="Ohne Stammnummer" Name="NoPID" />
                <Separator />
                <CollectionContainer Collection="{Binding Source={StaticResource ComboCollection}, Mode=OneWay}" />
            </CompositeCollection>
        </ComboBox.ItemsSource>
    </ComboBox>
