    <DataGrid AutoGenerateColumns="True"
            Name="myGrid"
            ItemsSource="{Binding Orders}"
            SelectionChanged="MyGrid_OnSelectionChanged">
        <DataGrid.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Copy"   Command="{Binding CopyItem}"/>
                <MenuItem Header="Delete" Command="{Binding DeleteItem}" />
            </ContextMenu>
        </DataGrid.ContextMenu>
    </DataGrid>
