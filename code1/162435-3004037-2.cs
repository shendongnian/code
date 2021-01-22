        public class CustomPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in Children)
                child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            return new Size(0, 0);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            double optimumHeight = finalSize.Height / Children.Count;
            var smallElements = Children.Cast<UIElement>().Where(c => c.DesiredSize.Height < optimumHeight);
            double leftOverHeight = smallElements.Sum(c => optimumHeight - c.DesiredSize.Height);
            var extraSpaceForBigElements = leftOverHeight / (Children.Count - smallElements.Count());
            double offset = 0.0;
            foreach (UIElement child in Children)
            {
                double height = child.DesiredSize.Height < optimumHeight ? child.DesiredSize.Height : optimumHeight + extraSpaceForBigElements;
                child.Arrange(new Rect(0, offset, finalSize.Width, height));
                offset += height;
            }
            return finalSize;
        }
    }
