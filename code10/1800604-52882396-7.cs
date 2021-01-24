    <ItemsControl ItemsSource="{Binding ViewModel.Fields}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Vertical" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="{Binding FieldName}" />
                    <TextBox Grid.Column="1" Text="{Binding Value}" IsReadOnly="{Binding IsReadOnly}"/>
                    <TextBlock Grid.Column="2" Text="{Binding TypeName}" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
