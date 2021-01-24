    <DataGrid ItemsSource="{Binding Students}" AutoGenerateColumns="True" CanUserAddRows="False">
        <DataGrid.Columns>
            <DataGridTemplateColumn>
                <DataGridTemplateColumn.HeaderTemplate>
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding DataContext.IsAllSelected, RelativeSource={RelativeSource AncestorType=DataGrid}}" Command="{Binding DataContext.CheckAllStudentsCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}" />
                    </DataTemplate>
                </DataGridTemplateColumn.HeaderTemplate>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding IsChecked, UpdateSourceTrigger=PropertyChanged}" Command="{Binding DataContext.CheckStudentCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
