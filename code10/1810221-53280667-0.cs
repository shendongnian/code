    <DataGrid x:Name="employeeDataGrid" 
            EnableRowVirtualization="True"
            ItemsSource="{Binding EmployeeViewSource}" Margin="10,77,10,0" 
            RowDetailsVisibilityMode="VisibleWhenSelected">
        <DataGrid.ContextMenu>
            <ContextMenu>
                <MenuItem Header="OpenDetail..."
                                  Command="{Binding PlacementTarget.DataContext.CmdOpenDetailEmployee, 
                                        RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                                  CommandParameter="{Binding}"/>
            </ContextMenu>
        </DataGrid.ContextMenu>
        <!--<DataGrid.Columns>...</DataGrid.Columns>-->
    </DataGrid>
