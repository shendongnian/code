    private UIElement draggedElement;
    private Point lastMousePos;
    private void MainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.OriginalSource != sender)
        {
            IInputElement canvas = (IInputElement)sender;
            canvas.CaptureMouse();
            draggedElement = e.OriginalSource as UIElement;
            lastMousePos = e.GetPosition(canvas);
        }
    }
    private void MainCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ((IInputElement)sender).ReleaseMouseCapture();
        draggedElement = null;
    }
    private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (draggedElement != null)
        {
            var newMousePos = e.GetPosition((IInputElement)sender);
            var dx = newMousePos.X - lastMousePos.X;
            var dy = newMousePos.Y - lastMousePos.Y;
            lastMousePos = newMousePos;
            Canvas.SetLeft(draggedElement, Canvas.GetLeft(draggedElement) + dx);
            Canvas.SetTop(draggedElement, Canvas.GetTop(draggedElement) + dy);
        }
    }
