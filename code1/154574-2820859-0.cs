    UIElement[] tmp = new UIElement[LayoutRoot.Children.Count];             
    LayoutRoot.Children.CopyTo(tmp, 0);  
    foreach (UIElement aElement in tmp)
    {
        Shape aShape = aElement as Shape; 
        if (aShape != null && aShape.Tag != null)
        {
            if (aShape.Tag.ToString().Contains("Bullet"))
            {
                if (Canvas.GetTop(aShape) + aShape.ActualHeight < 0) // This checks if it leaves the top
                {
                    LayoutRoot.Children.Remove(aElement);
                }
                else if(Canvas.GetTop(aShape) > Canvas.ActualHeight) // This condition checks if it leaves the bottom
                {
                    LayoutRoot.Children.Remove(aElement);
                }
            }
        }
    }
