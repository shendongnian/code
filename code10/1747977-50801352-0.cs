    <DataGrid ItemsSource="{Binding}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Name">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding DataContext.SomeObject.Name, RelativeSource={RelativeSource AncestorType=UserControl}}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                <DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <TextBox Text="{Binding DataContext.SomeObject.Name, RelativeSource={RelativeSource AncestorType=UserControl}}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellEditingTemplate>
            </DataGridTemplateColumn>
            <DataGridTextColumn Header="Name" Binding="{Binding SomeObject.Name}" />
        </DataGrid.Columns>
    </DataGrid>
