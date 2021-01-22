    private void Control_MouseMove(object sender, MouseEventArgs e)
    {
        var draggableControl = sender as UserControl;
    
        if (e.LeftButton == MouseButtonState.Pressed && draggableControl != null)
        {
            Point currentPosition = e.GetPosition(this.Parent as UIElement);
    
            var transform = draggableControl.RenderTransform as TranslateTransform;
            if (transform == null)
            {
                transform = new TranslateTransform();
                draggableControl.RenderTransform = transform;
            }
    
            transform.X = currentPosition.X - clickPosition.X;
            transform.Y = currentPosition.Y - clickPosition.Y;
        }
    }
