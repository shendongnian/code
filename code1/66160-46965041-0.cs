    <ComboBox ItemsSource="{Binding ComboBoxItems}" Grid.IsSharedSizeScope="True" HorizontalAlignment="Left">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition SharedSizeGroup="sharedSizeGroup"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="{Binding}"/>
                </Grid>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
