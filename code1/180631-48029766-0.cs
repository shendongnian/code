    public class ReversibleStackPanel : StackPanel
    {
        public bool ReverseOrder
        {
            get => (bool)GetValue(ReverseOrderProperty);
            set => SetValue(ReverseOrderProperty, value);
        }
        public static readonly DependencyProperty ReverseOrderProperty =
            DependencyProperty.Register(nameof(ReverseOrder), typeof(bool), typeof(ReversibleStackPanel), new PropertyMetadata(false));
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            bool fHorizontal = (Orientation == Orientation.Horizontal);
            var  rcChild = new Rect(arrangeSize);
            double previousChildSize = 0.0;
            var children = ReverseOrder ? InternalChildren.Cast<UIElement>().Reverse() : InternalChildren.Cast<UIElement>();
            foreach (UIElement child in children)
            {
                if (child == null)
                    continue;
                if (fHorizontal)
                {
                    rcChild.X += previousChildSize;
                    previousChildSize = child.DesiredSize.Width;
                    rcChild.Width = previousChildSize;
                    rcChild.Height = Math.Max(arrangeSize.Height, child.DesiredSize.Height);
                }
                else
                {
                    rcChild.Y += previousChildSize;
                    previousChildSize = child.DesiredSize.Height;
                    rcChild.Height = previousChildSize;
                    rcChild.Width = Math.Max(arrangeSize.Width, child.DesiredSize.Width);
                }
                child.Arrange(rcChild);
            }
            return arrangeSize;
        }
    }
