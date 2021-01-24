    private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
    {
        //assuming productList is a List<Product> which was set as ListView.ItemSource
        foreach (var product in productList)
        {
            if (product.IsOn == true)
            {
                ToggleTest.Text = product.ProductId.ToString();
                ToggleTest.Visibility = Visibility.Visible;
            }
            else
            {
                ToggleTest.Visibility = Visibility.Collapsed;
            }
        }
    }
