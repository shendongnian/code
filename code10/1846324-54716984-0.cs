    <DataGrid ItemsSource="{Binding Items}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Enable">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding Path=Enabled, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
                
            <DataGridTemplateColumn Header="Group">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Path=Group}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                <DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <TextBox Text="{Binding Path=Group}" IsEnabled="{Binding Path=Enabled, Mode=TwoWay}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellEditingTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
