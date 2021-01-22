    protected override Size MeasureOverride(Size availableSize)
    {
        Size sizeSoFar = new Size(0, 0);
        double maxWidth = 0.0;
    
        foreach (UIElement child in Children)
        {
            child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    
            if (sizeSoFar.Width + child.DesiredSize.Width > availableSize.Width)
            {
                sizeSoFar.Height += child.DesiredSize.Height;
                sizeSoFar.Width = 0;
            }
            else
            {
                sizeSoFar.Width += child.DesiredSize.Width;
                maxWidth = Math.Max(sizeSoFar.Width, maxWidth);
            }
        }
    
        return new Size(maxWidth, sizeSoFar.Height);
    }
