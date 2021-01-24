    <StackPanel>
        <DataGrid x:Name="dataEmployee"  IsReadOnly="True" VerticalAlignment="Top" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Employee Id" Binding="{Binding EmployeeId}"/>
                <DataGridTextColumn Header="Employee Name" Binding="{Binding EmployeeName}"/>
                <DataGridTextColumn Header="Salary" Binding="{Binding EmployeeSalary}"/>
                <DataGridTextColumn Header="Designation" Binding="{Binding EmployeeDesignation}"/>
            </DataGrid.Columns>
        </DataGrid>
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="Name"/>
            <TextBox Text="{Binding ElementName=dataEmployee, Path=SelectedItem.EmployeeName}"/></StackPanel>
    </StackPanel>
