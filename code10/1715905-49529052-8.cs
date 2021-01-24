    private void DiableAllButThisAndItsParents(FrameworkElement thisElement)
    {
        List<FrameworkElement> hierarchy = FindParents(thisElement).ToList();
        foreach (FrameworkElement element in hierarchy)
        {
            element.IsEnabled = true;
            if (ReferenceEquals(element, thisElement)) continue;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                var child = VisualTreeHelper.GetChild(element, i);
                if (!(child is FrameworkElement childElement)) continue;
                childElement.IsEnabled = hierarchy.Contains(childElement);
            }
        }
    }
    private IEnumerable<FrameworkElement> FindParents(FrameworkElement element)
    {
        DependencyObject current = element;
        while (current != null)
        {
            if (current is FrameworkElement)
                yield return (FrameworkElement) current;
            current = VisualTreeHelper.GetParent(current);
        }
    }
