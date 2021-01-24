    private void ListBox_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        ListBox lb = sender as ListBox;
        ItemsPresenter ip = FindVisualChild<ItemsPresenter>(lb);
        StackPanel sp = FindVisualChild<StackPanel>(ip);
        UIElement lastElement = sp.Children[sp.Children.Count - 1];
        bool isLastElementVisible = IsElementVisible(lastElement);
        if (e.NewSize.Width < e.PreviousSize.Width && !isLastElementVisible)
            sp.Orientation = Orientation.Vertical;
        else if (e.NewSize.Width > e.PreviousSize.Width && isLastElementVisible)
            sp.Orientation = Orientation.Horizontal;
    }
    private static T FindVisualChild<T>(DependencyObject parent, string childName = null) where T : DependencyObject
    {
        int count = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < count; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            var childElement = child as FrameworkElement;
            if (child is T && (childName == null || (childElement != null && childElement.Name == childName)))
            {
                return child as T;
            }
            else
            {
                var grandchild = FindVisualChild<T>(child, childName);
                if (grandchild is T)
                {
                    return grandchild;
                }
            }
        }
        return null;
    }
    private static bool IsElementVisible(UIElement element)
    {
        if (!element.IsVisible)
            return false;
        var container = VisualTreeHelper.GetParent(element) as FrameworkElement;
        if (container == null) throw new ArgumentNullException("container");
        Rect bounds = element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.RenderSize.Width, element.RenderSize.Height));
        Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
        return rect.IntersectsWith(bounds);
    }
