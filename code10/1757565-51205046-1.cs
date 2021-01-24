    private Point? mousePos;
    private void RectangleMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ((IInputElement)sender).CaptureMouse();
        mousePos = e.GetPosition(canvas);
    }
    private void RectangleMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ((IInputElement)sender).ReleaseMouseCapture();
        mousePos = null;
    }
    private void RectangleMouseMove(object sender, MouseEventArgs e)
    {
        if (mousePos.HasValue)
        {
            var rectangle = (Rectangle)sender;
            var transform = (MatrixTransform)rectangle.RenderTransform;
            var matrix = transform.Matrix;
            var pos = e.GetPosition(canvas);
            matrix.Translate(pos.X - mousePos.Value.X, pos.Y - mousePos.Value.Y);
            transform.Matrix = matrix;
            mousePos = pos;
        }
    }
    private void RectangleMouseWheel(object sender, MouseWheelEventArgs e)
    {
        var rectangle = (Rectangle)sender;
        var transform = (MatrixTransform)rectangle.RenderTransform;
        var matrix = transform.Matrix;
        var pos = e.GetPosition(canvas);
        matrix.RotateAt(e.Delta > 0 ? 22.5 : -22.5, pos.X, pos.Y);
        transform.Matrix = matrix;
    }
