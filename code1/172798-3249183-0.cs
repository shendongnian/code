        <DataTemplate x:Key="clientTemplate" DataType="{x:Type local:Client}">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto" />
                    <ColumnDefinition />
                </Grid.ColumnDefinitions>
                <CheckBox IsChecked="{Binding IsSelected}" />
                <TextBlock Grid.Column="1" Text="{Binding Name}" Margin="5,0,0,0" />
            </Grid>
        </DataTemplate>
