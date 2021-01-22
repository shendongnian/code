    <DataGrid ItemsSource="{Binding Employees}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Employee Name" Binding="{Binding Name}" />
            <DataGridTextColumn Header="Company Name" Binding="{Binding Company.Name}" />
        </DataGrid.Columns>
    </DataGrid>
