    <data:DataGrid x:Name="testDataGrid" GridLinesVisibility="Horizontal" Width="150" SizeChanged="testDataGrid_SizeChanged" />
-
    private void testDataGrid_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        this.testDataGrid.Columns[0].Visibility = Visibility.Collapsed;
        this.testDataGrid.Columns[0].Visibility = Visibility.Visible;
    }
