    class DottedLineAdorner : Adorner
    {
        public UIElement AdornedElement { get; set; }
        public DottedLineAdorner(UIElement adornedElement) : base(adornedElement)
        {
            AdornedElement = adornedElement;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            Size eltSize = (AdornedElement as FrameworkElement).DesiredSize;
            Pen pen = new Pen(Brushes.Blue, 2) { DashStyle = DashStyles.DashDot };
            drawingContext.DrawRoundedRectangle(null, pen, new Rect(0, 0, eltSize.Width, eltSize.Height), 10, 10);
        }
    }
