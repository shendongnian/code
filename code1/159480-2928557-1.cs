    protected override Size ArrangeOverride(Size finalSize)
    {
        Size sizeSoFar = new Size(0, 0);
    
        foreach (UIElement child in Children)
        {
            child.Arrange(new Rect(sizeSoFar.Width, sizeSoFar.Height, 
                                   child.DesiredSize.Width, child.DesiredSize.Height));
    
            if (sizeSoFar.Width + child.DesiredSize.Width >= finalSize.Width)
            {
                sizeSoFar.Height += child.DesiredSize.Height;
                sizeSoFar.Width = 0;
            }
            else
            {
                sizeSoFar.Width += child.DesiredSize.Width;
            }
        }
    
        return finalSize;
    }
