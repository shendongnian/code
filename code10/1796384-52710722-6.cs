    public class WeightedUniformGrid : UniformGrid
    {
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.RegisterAttached(
                "Weight", typeof(double), typeof(WeightedUniformGrid),
                new FrameworkPropertyMetadata(double.NaN,
                    FrameworkPropertyMetadataOptions.AffectsParentMeasure |
                    FrameworkPropertyMetadataOptions.AffectsParentArrange));
        public static double GetWeight(UIElement element)
        {
            return (double)element.GetValue(WeightProperty);
        }
        public static void SetWeight(UIElement element, double value)
        {
            element.SetValue(WeightProperty, value);
        }
        protected override Size MeasureOverride(Size constraint)
        {
            var size = base.MeasureOverride(constraint);
            double elementsPerRow = Math.Ceiling((double)Children.Count / Rows);
            double elementHeight = size.Height / Rows;
            double unweightedElementWidth = size.Width / elementsPerRow;
            for (int i = 0; i < Children.Count; ++i)
            {
                var child = Children[i];
                int rowNumber = (int)Math.Floor(i / elementsPerRow);
                // get attached property value
                double weight = GetWeight(child);
                if (double.IsNaN(weight)) { weight = 100; }
                double weightedElementWidth = unweightedElementWidth * weight / 100;
                child.Measure(new Size(weightedElementWidth, elementHeight));
            }
            return size;
        }
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var size = base.ArrangeOverride(arrangeSize);
            int elementsPerRow = (int)Math.Ceiling((double)Children.Count / Rows);
            double elementHeight = size.Height / Rows;
            double unweightedElementWidth = size.Width / elementsPerRow;
            double[] accumulatedWidthPerRow = new double[Rows];
            for (int i = 0; i < Children.Count; ++i)
            {
                var child = Children[i];
                int rowNumber = i / elementsPerRow;
                // get attached property value
                double weight = GetWeight(child);
                if (double.IsNaN(weight)) { weight = 100; }
                double weightedElementWidth = unweightedElementWidth * (double)weight / 100;
                child.Arrange(new Rect(new Point(accumulatedWidthPerRow[rowNumber], rowNumber * elementHeight),
                                        new Point(accumulatedWidthPerRow[rowNumber] + weightedElementWidth, (rowNumber + 1) * elementHeight)));
                accumulatedWidthPerRow[rowNumber] += weightedElementWidth;
            }
            return size;
        }
    }
