    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!_appeared)
        {
            try
            {
                ProductViewData productViewData = new ProductViewData();
                // make the method asynchronous
                products = productViewData.GetProductListAsync("10");
                count = 10;
                productListView.ItemsSource = products;
                _appeared = true;
            }
            catch(Exception exception)
            {
                // good idea to catch any network exceptions
            }
        }
    }
