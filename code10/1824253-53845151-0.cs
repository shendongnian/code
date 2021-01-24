    private void LstPlayerItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (((ListBox)sender).SelectedIndex != -1)
            LstStoreItems.UnselectAll();
        BtnBuy.IsEnabled = false;
        BtnSell.IsEnabled = true;
    }
    private void LstStoreItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (((ListBox)sender).SelectedIndex != -1)
            LstPlayerItems.UnselectAll();
        BtnBuy.IsEnabled = true;
        BtnSell.IsEnabled = false;
    }
