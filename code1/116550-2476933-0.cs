    private static Point GetCanvasChildPosition(FrameworkElement element)
    {
        var canvas = element.Parent as Canvas;
    
        double left = Canvas.GetLeft(element);
        double top = Canvas.GetTop(element);
    
        bool isLeftAligned = !double.IsNaN(left);
        bool isTopAligned = !double.IsNaN(top);
    
        double x;
        double y;
    
        if (isLeftAligned)
        {
            x = left;
        }
        else
        {
            x = canvas.Width - Canvas.GetRight(element) - element.Width;
        }
    
        if (isTopAligned)
        {
            y = top;
        }
        else
        {
            y = canvas.Height - Canvas.GetBottom(element) - element.Height;
        }
    
        return new Point(x, y);
    }
