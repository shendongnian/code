    private void Reset(object sender, RoutedEventArgs e)
    {
    	dtextbox.Reset();
    }
    
    private void ResetWithValue(object sender, RoutedEventArgs e)
    {
    	dtextbox.Reset("Magic Reset");
    }
    
    private void UpdateText(object sender, RoutedEventArgs e)
    {
    	dtextbox.Text = "updated text";
    }
