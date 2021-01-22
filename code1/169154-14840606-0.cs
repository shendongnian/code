    public class ContainerAdorner : Adorner
    {
        // To store and manage the adorner's visual children.
        VisualCollection visualChildren;
        // Override the VisualChildrenCount and GetVisualChild properties to interface with 
        // the adorner's visual collection.
        protected override int VisualChildrenCount { get { return visualChildren.Count; } }
        protected override Visual GetVisualChild(int index) { return visualChildren[index]; }
        // Initialize the ResizingAdorner.
        public ContainerAdorner (UIElement adornedElement)
            : base(adornedElement)
        {
            visualChildren = new VisualCollection(this);
            visualChildren.Add(_Container);
        }
        ContainerClass _Container= new ContainerClass();
        protected override Size ArrangeOverride(Size finalSize)
        {
            // desiredWidth and desiredHeight are the width and height of the element that's being adorned.  
            // These will be used to place the Adorner at the corners of the adorned element.  
            double desiredWidth = AdornedElement.DesiredSize.Width;
            double desiredHeight = AdornedElement.DesiredSize.Height;
            FrameworkElement fe;
            if ((fe = AdornedElement as FrameworkElement) != null)
            {
                desiredWidth = fe.ActualWidth;
                desiredHeight = fe.ActualHeight;
            }
            _Container.Arrange(new Rect(0, 0, desiredWidth, desiredHeight));
            return finalSize;
        }
    }
