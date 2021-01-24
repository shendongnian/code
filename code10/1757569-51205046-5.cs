    private Point? mousePos;
    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ((IInputElement)sender).CaptureMouse();
        mousePos = e.GetPosition(canvas);
    }
    private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ((IInputElement)sender).ReleaseMouseCapture();
        mousePos = null;
    }
    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (mousePos.HasValue)
        {
            var element = (UIElement)sender;
            var transform = (MatrixTransform)element.RenderTransform;
            var matrix = transform.Matrix;
            var pos = e.GetPosition(canvas);
            matrix.Translate(pos.X - mousePos.Value.X, pos.Y - mousePos.Value.Y);
            transform.Matrix = matrix;
            mousePos = pos;
        }
    }
    private void OnMouseWheel(object sender, MouseWheelEventArgs e)
    {
        var element = (UIElement)sender;
        var transform = (MatrixTransform)element.RenderTransform;
        var matrix = transform.Matrix;
        var pos = e.GetPosition(canvas);
        matrix.RotateAt(e.Delta > 0 ? 22.5 : -22.5, pos.X, pos.Y);
        transform.Matrix = matrix;
    }
