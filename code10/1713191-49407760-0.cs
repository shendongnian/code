    public static IEnumerable<UIElement> GetChildren(this ItemsControl itemsControl)
    {
        foreach(var item in itemsControl.Items)
        {
            yield return (UIElement) ItemsControl.ItemContainerGenerator.ContainerFromItem(item);
        }
    }
