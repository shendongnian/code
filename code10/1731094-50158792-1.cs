    <ComboBox xmlns:o="clr-namespace:APP.GLN_Organisator.Objects">
        <ComboBox.Resources>
            <CollectionViewSource x:Key="ComboCollection"
                                  Source="{Binding Path=mySelectedItem.Stammkinder}" />
            <!-- Define a DataTemplate here -->
            <DataTemplate DataType="{x:Type o:ChildPartner}">
                <TextBlock Text="{Binding PartnerID}"/>
            </DataTemplate>
        </ComboBox.Resources>
        <ComboBox.ItemsSource>
            <CompositeCollection>
                <ComboBoxItem Content="Ohne Stammnummer" Name="NoPID" />
                <Separator />
                <CollectionContainer Collection="{Binding Source={StaticResource ComboCollection}}" />
            </CompositeCollection>
        </ComboBox.ItemsSource>
    </ComboBox>
