    <ComboBox IsEditable="True"
              TextBlock.Foreground="{Binding SelectedItem.ALV_COULEUR, Converter={StaticResource IntToBrushConverter}, RelativeSource={RelativeSource Self}}">
              ItemsSource="{Binding tValeur, Mode=OneWay}" SelectedValuePath="ALV_ID" DisplayMemberPath="ALV_VALEUR"
              SelectedValue="{Binding ATT_VALEUR, Converter={StaticResource StringToIntConverter}, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
              IsEnabled="{Binding IsEnabled, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding ALV_VALEUR}" Foreground="{Binding ALV_COULEUR, Converter={StaticResource IntToBrushConverter}}" />
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
