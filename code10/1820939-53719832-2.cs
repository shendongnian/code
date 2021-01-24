    private Product _updatedProduct;
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        int id = (int)e.Parameter;
        //assign to the private field
        _updatedProduct = data.GetProductById(id);
    
        nameTextBox.Text = _updatedProduct.ProductName;
        priceTextBox.Text = _updatedProduct.Price.ToString();
        quantityTextBox.Text = _updatedProduct.Quantity.ToString();
        descTextBox.Text = _updatedProduct.Description;
    }
    
    private async void saveButton_Click(object sender, RoutedEventArgs e)
    {
        //update properties of the private field
        _updatedProduct.ProductName = nameTextBox.Text;
        _updatedProduct.Price = double.Parse(priceTextBox.Text);
        _updatedProduct.Quantity = int.Parse(quantityTextBox.Text);
        _updatedProduct.Description = descTextBox.Text;
    
        if (data.UpdateProduct(_updatedProduct))
        {
            MessageDialog md = new MessageDialog("Product changes updated", "UPDATE OUTCOME");
            await md.ShowAsync();
        }
        else
        {
            MessageDialog md = new MessageDialog("Product changes NOT updated", "UPDATE OUTCOME");
            await md.ShowAsync();
        }
    
        Frame.Navigate(typeof(MainPage));
    }
