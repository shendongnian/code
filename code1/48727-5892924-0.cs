    <DataGrid Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="2" Name="dgMissingNames" ItemsSource="{Binding Path=TheMissingChildren}" Style="{StaticResource NameListGrid}" SelectionChanged="DataGrid_SelectionChanged">
        <DataGrid.Columns>
            <DataGridTemplateColumn CellStyle="{StaticResource NameListCol}">
                <DataGridTemplateColumn.HeaderTemplate>
                    <DataTemplate>
                        <CheckBox Checked="CheckBox_Checked" Unchecked="CheckBox_Unchecked" />
                    </DataTemplate>                            
                </DataGridTemplateColumn.HeaderTemplate>
                <DataGridTemplateColumn.CellTemplate>                        
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding Path=Checked, UpdateSourceTrigger=PropertyChanged}" Name="theCheckbox"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>                            
            </DataGridTemplateColumn>
            <DataGridTextColumn Binding="{Binding Path=SKU}" Header="Album" CellStyle="{StaticResource NameListCol}"/>
            <DataGridTextColumn Binding="{Binding Path=Name}" Header="Name" CellStyle="{StaticResource NameListCol}"/>
            <DataGridTextColumn Binding="{Binding Path=Pronunciation}" Header="Pronunciation" CellStyle="{StaticResource NameListCol}"/>
        </DataGrid.Columns>
    </DataGrid>
