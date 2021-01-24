    public class CanvasAutoSize : Canvas
    {
    protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint)
    {
        base.MeasureOverride(constraint);
        double width = base
            .InternalChildren
            .OfType<UIElement>()
            .Max(i => i.DesiredSize.Width + (double)i.GetValue(Canvas.LeftProperty));
        double height = base
            .InternalChildren
            .OfType<UIElement>()
            .Max(i => i.DesiredSize.Height + (double)i.GetValue(Canvas.TopProperty));
        return new Size(width, height);
    }
    }
