    private void testCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        var scaleX = e.NewSize.Width / e.PreviousSize.Width;
        var scaleY = e.NewSize.Height / e.PreviousSize.Height;
        for (int i = 0; i < testCanvas.Children.Count; i++)
        {
            UIElement ui = testCanvas.Children[i];
            
            double left = Canvas.GetLeft(ui);
            double top = Canvas.GetTop(ui);
            double right = Canvas.GetRight(ui);
            double bottom = Canvas.GetBottom(ui);
        }
    }
