    private void MovieBox_OnTapped(object sender, TappedRoutedEventArgs e)
    {
        var id = Convert.ToString((sender as StackPanel).Tag);
    	
    	Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
    	() =>
    	{
    		Frame.Navigate(typeof(MovieDetailsPage), id);
    	});
    }
    
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        
    	if(e.Parameter != null)
    	{
    		string text = Convert.ToString(e.Parameter);
    	}    
    }
