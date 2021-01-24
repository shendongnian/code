    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!_appeared) // Avoid repeat loding
        {
            _appeared = true;
            activity.IsEnabled = true;
            activity.IsRunning = true;
            activity.IsVisible = true;
            await Task.Run(() =>
            {
                ProductViewData productViewData = new ProductViewData();
                products = productViewData.GetProductList("10");
                count = 10;
                productListView.ItemsSource = products;
            });
            activity.IsEnabled = false;
            activity.IsRunning = false;
            activity.IsVisible = false;
        }
    }
