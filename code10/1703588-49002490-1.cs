        protected override void OnAppearing()
        {
            base.OnAppearing();
            view = new WebView();
            Content = new StackLayout
            {
                Children = { view }
            };
            view.Navigated += View_Navigated;
            view.Source = "http://xamarin.com";
        }
        private void View_Navigated(object sender, WebNavigatedEventArgs e)
        {
            (sender as WebView).HeightRequest = Height;
        }
