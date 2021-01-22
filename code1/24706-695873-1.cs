    private double aspectRatio = 0.0;
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        aspectRatio = this.ActualWidth / this.ActualHeight;
    }
    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        if (sizeInfo.WidthChanged)
        {
            this.Width = sizeInfo.NewSize.Height * aspectRatio;
        }
        else
        {
            this.Height = sizeInfo.NewSize.Width * aspectRatio;
        }
    }
