    private void ScrollViewerMouseEnter(object sender, MouseEventArgs e)
    {
        ((ScrollViewer)sender).CaptureMouse();
    }
    private void ScrollViewerMouseLeave(object sender, MouseEventArgs e)
    {
        ((ScrollViewer)sender).ReleaseMouseCapture();
    }
