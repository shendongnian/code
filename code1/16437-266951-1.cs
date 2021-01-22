    public class TestBox : ListBox
    {
        private ScrollViewer _scrollHost;
    
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var itemsHost = VisualTreeHelper.GetParent(element) as Panel;
    
            for (DependencyObject obj = itemsHost; obj != item && obj != null; obj = VisualTreeHelper.GetParent(obj))
            {
                ScrollViewer viewer = obj as ScrollViewer;
                if (viewer != null)
                {
                    _scrollHost = viewer;
                    break;
                }
             }
    
            base.PrepareContainerForItemOverride(element, item);
        }
    }
