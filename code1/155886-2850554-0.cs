    <DataGrid 
        AlternatingRowBackground="AliceBlue" 
        ItemsSource="{Binding}" 
        AutoGenerateColumns="False" 
        Height="200" 
        HorizontalAlignment="Left"
        Margin="156,58,0,0" 
        Name="dataGrid1" 
        VerticalAlignment="Top"
        Width="200" LoadingRow="dataGrid1_LoadingRow">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding}" />
        </DataGrid.Columns>
    </DataGrid>
    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        ObservableCollection<string> list = new ObservableCollection<string>();
        list.Add("test1");
        list.Add("test2");
        list.Add("test3");
        list.Add("test4");
        list.Add("test5");
        dataGrid1.ItemsSource = list;
    }
    private void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        if (e.Row.Item.ToString() == "test2")
        {
            e.Row.Background = Brushes.Red;
        }
    }
