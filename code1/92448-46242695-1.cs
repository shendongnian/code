    private object movingObject;
    private double firstXPos, firstYPos;
    private int ButtonSize = 50;
    
    private void BtTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Button newBtn = sender as Button;
        Canvas canvas = newBtn.Parent as Canvas;
    
        firstXPos = e.GetPosition(newBtn).X;
        firstYPos = e.GetPosition(newBtn).Y - ButtonSize;
    
        movingObject = sender;
    
        // Put the image currently being dragged on top of the others
        int top = Canvas.GetZIndex(newBtn);
        foreach (Button child in canvas.Children)
            if (top < Canvas.GetZIndex(child))
                top = Canvas.GetZIndex(child);
        Canvas.SetZIndex(newBtn, top + 1);
        Mouse.Capture(null);
    }
    
    private void BtTable_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        Button newBtn = sender as Button;
        Canvas canvas = newBtn.Parent as Canvas;
    
        movingObject = null;
    
        // Put the image currently being dragged on top of the others
        int top = Canvas.GetZIndex(newBtn);
        foreach (Button child in canvas.Children)
            if (top > Canvas.GetZIndex(child))
                top = Canvas.GetZIndex(child);
        Canvas.SetZIndex(newBtn, top + 1);
        Mouse.Capture(newBtn);
    }
    
    private void BtTable_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed && sender == movingObject)
        {
            Button newBtn = sender as Button;
            Canvas canvas = newBtn.Parent as Canvas;
            // Horizontal
            double newLeft = e.GetPosition(canvas).X - firstXPos - canvas.Margin.Left;
            // newLeft inside canvas right-border?
            if (newLeft > canvas.Margin.Left + canvas.ActualWidth - newBtn.ActualWidth)
                newLeft = canvas.Margin.Left + canvas.ActualWidth - newBtn.ActualWidth;
            // newLeft inside canvas left-border?
            else if (newLeft < canvas.Margin.Left)
                newLeft = canvas.Margin.Left;
    
            newBtn.SetValue(Canvas.LeftProperty, newLeft);
    
            //Vertical
            double newTop = e.GetPosition(canvas).Y - firstYPos - canvas.Margin.Top;
            // newTop inside canvas bottom-border?
            // -- Bottom --
            if (newTop > canvas.Margin.Top + canvas.ActualHeight - newBtn.ActualHeight - ButtonSize)
                newTop = canvas.Margin.Top + canvas.ActualHeight - newBtn.ActualHeight - ButtonSize;
            // newTop inside canvas top-border?
            // -- Top --
            else if (newTop < canvas.Margin.Top - ButtonSize)
                newTop = canvas.Margin.Top - ButtonSize;
    
            newBtn.SetValue(Canvas.TopProperty, newTop);
        }
    }
