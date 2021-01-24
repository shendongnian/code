    protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!_appeared) // Avoid repeat loding
            {
                activity.IsEnabled = true;
                activity.IsRunning = true;
                activity.IsVisible = true;
                var task = Task.Run(() =>
                {
                    ProductViewData productViewData = new ProductViewData();
                    products = productViewData.GetProductList("10");
                    count = 10;
                    productListView.ItemsSource = products;
                });
                _appeared = true;
            }
        }
