    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        CaptureMouse();
    }
    private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (!IsMouseCaptured)
            return;
        ReleaseMouseCapture();
        var dlg = new OpenFileDialog();
        var res = dlg.ShowDialog(this);
        // ...
    }
