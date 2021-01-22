    public class CustomPanel:Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in Children)
                child.Measure(new Size(double.PositiveInfinity,double.PositiveInfinity));
            return new Size(0,0);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            double remainingSpace = Math.Max(0.0,finalSize.Height - Children.Cast<UIElement>().Sum(c => c.DesiredSize.Height));
            var extraSpace = remainingSpace / Children.Count;
            double offset = 0.0;
            foreach (UIElement child in Children)
            {
                double height = child.DesiredSize.Height + extraSpace;
                child.Arrange(new Rect(0, offset, finalSize.Width, height));
                offset += height;
            }
            return finalSize;
        }
    }
