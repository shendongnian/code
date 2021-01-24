    private UIElement draggedElement;
    private Point lastMousePos;
    private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.OriginalSource != sender)
        {
            IInputElement canvas = (IInputElement)sender;
            canvas.CaptureMouse();
            draggedElement = e.OriginalSource as UIElement;
            lastMousePos = e.GetPosition(canvas);
        }
    }
    private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ((IInputElement)sender).ReleaseMouseCapture();
        draggedElement = null;
    }
    private void CanvasMouseMove(object sender, MouseEventArgs e)
    {
        if (draggedElement != null)
        {
            var p = e.GetPosition((IInputElement)sender);
            var dx = p.X - lastMousePos.X;
            var dy = p.Y - lastMousePos.Y;
            lastMousePos = p;
            Canvas.SetLeft(draggedElement, Canvas.GetLeft(draggedElement) + dx);
            Canvas.SetTop(draggedElement, Canvas.GetTop(draggedElement) + dy);
        }
    }
