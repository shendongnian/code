    protected override void OnAppearing()
        {
            activityIndicator.IsRunning = true;
            SummaryRepository viewModel = new SummaryRepository();
    
            listView.ItemsSource = viewModel.Summary;
            listView.ItemTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
    
                var bookName = new Label
                {
                    BackgroundColor = Color.White,
                    FontSize = 16,
                    TextColor = Color.FromHex("#1A237E")
                };
                var bookDescription = new Label
                {
                    BackgroundColor = Color.White,
                    FontSize = 16,
                    HorizontalTextAlignment = TextAlignment.End,
                    TextColor = Color.FromHex("#EC407A")
                };
    
                bookName.SetBinding(Label.TextProperty, new Binding("Name"));
                bookDescription.SetBinding(Label.TextProperty, new Binding("Amount"));
    
                grid.Children.Add(bookName);
                grid.Children.Add(bookDescription, 1, 0);
    
                return grid;
            });
    
            activityIndicator.IsRunning = false;
    
            base.OnAppearing();
        }
