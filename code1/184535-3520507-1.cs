    public class MyUniformGrid : UniformGrid
    {
        protected override UIElementCollection CreateUIElementCollection(FrameworkElement logicalParent)
        {
            return new ObservableUIElementCollection(this, logicalParent);
        }
    }
