    public class CustomItemsCollection
        : ItemsControl
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            FrameworkElement contentitem = element as FrameworkElement;
            Binding leftBinding = new Binding("Left"); // "Left" is the property path that you want to bind the value to.
            contentitem.SetBinding(Canvas.LeftProperty, leftBinding);
            
            base.PrepareContainerForItemOverride(element, item);
        }
    }
