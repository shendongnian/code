    public class RelativePositionCanvas : Panel
    {
        #region Properties
        #region RelativeX
        public static readonly DependencyProperty RelativeXProperty =
            DependencyProperty.RegisterAttached(
                    "RelativeX",
                    typeof(double),
                    typeof(RelativePositionCanvas),
                    new FrameworkPropertyMetadata(
                            0.0d, 
                            new PropertyChangedCallback(OnPositioningChanged)));
        public static double GetRelativeX(DependencyObject d)
        {
            return (double)d.GetValue(RelativeXProperty);
        }
        public static void SetRelativeX(DependencyObject d, double value)
        {
            d.SetValue(RelativeXProperty, value);
        }
        #endregion
        #region RelativeY
        public static readonly DependencyProperty RelativeYProperty =
            DependencyProperty.RegisterAttached(
                    "RelativeY",
                    typeof(double),
                    typeof(RelativePositionCanvas),
                    new FrameworkPropertyMetadata(
                            0.0d,
                            new PropertyChangedCallback(OnPositioningChanged)));
        public static double GetRelativeY(DependencyObject d)
        {
            return (double)d.GetValue(RelativeYProperty);
        }
        public static void SetRelativeY(DependencyObject d, double value)
        {
            d.SetValue(RelativeYProperty, value);
        }
        #endregion
        private static void OnPositioningChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                RelativePositionCanvas p = VisualTreeHelper.GetParent(uie) as RelativePositionCanvas;
                if (p != null)
                    p.InvalidateArrange();
            }
        }
        #endregion
        protected override Size MeasureOverride(Size availableSize)
        {
            Size childConstraint = new Size(Double.PositiveInfinity, Double.PositiveInfinity);
            foreach (UIElement child in InternalChildren)
            {
                if (child == null) { continue; }
                child.Measure(childConstraint);
            }
            return new Size();
        }
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var children = this.Children;
            foreach(UIElement child in children)
            {
                if (child == null) { continue; }
                var childRelativeX = GetRelativeX(child);
                var childRelativeY = GetRelativeY(child);
                var posX = childRelativeX * arrangeSize.Width;
                var posY = childRelativeY * arrangeSize.Height;
                child.Arrange(new Rect(new Point(posX, posY), child.DesiredSize));
            }
            return arrangeSize;
        }
    }
