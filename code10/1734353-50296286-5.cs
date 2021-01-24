    protected override void OnAppearing()
        {
            ReportListView.ItemsSource = //your items;
            reportIndicator.IsVisible = false;
            reportIndicator.IsRunning = false;
            reportIndicator.IsEnabled = false;
                
            base.OnAppearing();            
        }
