    private async void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        rowClickCount++;
        await Task.Delay(200);
        if (rowClickCount ==2)
        {
            rowClickCount = 0;
            MessageBox.Show("Invoke command");
        }
        rowClickCount = 0;
    }
