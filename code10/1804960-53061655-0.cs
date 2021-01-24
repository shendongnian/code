    <Grid>
        <FrameworkElement x:Name="Proxy" Visibility="Collapsed" />
        <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Customers}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
                <DataGridTextColumn Header="Name" Binding="{Binding Surname}" />
                <DataGridTextColumn Header="Name" Binding="{Binding Age}" />
                <DataGridTemplateColumn Visibility="{Binding DataContext.IsShown, Converter={StaticResource BoolToVisibilityConverter}, Source={x:Reference Proxy}}">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Content="Test" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
            <DataGrid.ItemContainerStyle>
                <Style TargetType="{x:Type DataGridRow}">
                </Style>
            </DataGrid.ItemContainerStyle>
        </DataGrid>
    </Grid>
