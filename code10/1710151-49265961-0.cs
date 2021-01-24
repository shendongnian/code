    public void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selected = LstView.SelectedItem as Product;
        if (selected != null)
        {
            SelectedProductName.Text = selected.ProductId.ToString();
        }
        else
        {
            SelectedProductName.Text = "Default Product Name";
        }
    }
