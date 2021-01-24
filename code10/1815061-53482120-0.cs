    private void sumButton_Click(object sender, RoutedEventArgs e)
    {
        int sum = 0;
        for (int i = 0; i < TruckDataGrid2.Items.Count; ++i)
        {
            Car car = TruckDataGrid2.Items[i] as Car; //try to cast item to your data object type
            if (car != null)
                sum += car.Price;
        }
        sumText.Text = sum.ToString();
    }
