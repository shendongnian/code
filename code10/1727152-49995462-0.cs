     <DataGrid Name="Users" AutoGenerateColumns="False">
                           
    
         <DataGrid Name="dgUsers" AutoGenerateColumns="False">
                                <DataGrid.Columns>
        
                                        <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
        
                                        <DataGridTemplateColumn Header="Birthday">
                                                <DataGridTemplateColumn.CellTemplate>
                                                        <DataTemplate>
                                                                <DatePicker SelectedDate="{Binding Birthday}" BorderThickness="0" />
                                                        </DataTemplate>
                                                </DataGridTemplateColumn.CellTemplate>
                                        </DataGridTemplateColumn>
        
                                </DataGrid.Columns>
                        </DataGrid>
