    protected override Size MeasureOverride(Size availableSize)
    {
        var height = 0.0;
        var width = 0.0;
        foreach (UIElement child in InternalChildren)
        {
            child.Measure(availableSize);
            if (child.DesiredSize.Width > width) width = child.DesiredSize.Width;
            height += child.DesiredSize.Height;
        }
 
        width = double.IsPositiveInfinity(availableSize.Width) ? width : Math.Min(width, availableSize.Width);
        height = double.IsPositiveInfinity(availableSize.Height) ? height : Math.Min(height, availableSize.Height); 
        
        return new Size(width, height);
    }
