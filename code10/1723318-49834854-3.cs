        <DataGrid Name="StockDataGrid"
                  ItemsSource="{Binding}"             
                  AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="ID" Binding="{Binding StockId }"></DataGridTextColumn>
                <DataGridTextColumn Header="Name" Binding="{Binding StockName }"></DataGridTextColumn>
                <DataGridTextColumn Header="Price" Binding="{Binding StockPrice}"></DataGridTextColumn>
                <DataGridTextColumn Header="Supplier ID" Binding="{Binding Suppliers.SupplierId}"></DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
