    Point start;
    Point origin;
    private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        image.CaptureMouse();
        start = e.GetPosition(image);
        origin = image.RenderTransformOrigin;
    }
