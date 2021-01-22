    private void imageScroller_Loaded(object sender, RoutedEventArgs e)
    {
        FitToWidth();
    }
    
    private void imageScroller_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if(imageScroller.IsLoaded)
            FitToWidth();
    }
    
    private void FitToWidth()
    {
        scaler.ScaleX = scaler.ScaleY = imageScroller.ActualWidth / imageViewer.Source.Width;
    }
