    public class MyScrollViewer : ScrollViewer
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            drawingContext.DrawLine(new Pen(Brushes.LimeGreen, 11.0),
                    new Point(1, 1), new Point(115, 115));
        }
    }
