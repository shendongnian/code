    private void btnFindLocation_OnClick(object sender, RoutedEventArgs e)
    {
        var target = sender as DependencyObject;
        while (target != null)
        {
            target = VisualTreeHelper.GetParent(target);
            if (target is MenuFlyoutItem menuFlyoutItem)
            {
                if (GetChild<TextBox>(menuFlyoutItem) is TextBox textBox)
                {
                    // Access the TextBox here
                    Debug.WriteLine(textBox.Text);
                }
            }
        }
    }
    private TFrameworkElement GetChild<TFrameworkElement>(FrameworkElement parent) where TFrameworkElement : FrameworkElement
    {
        var count = VisualTreeHelper.GetChildrenCount(parent);
        for (var index = 0; index < count; ++index)
        {
            var child = VisualTreeHelper.GetChild(parent, index) as FrameworkElement;
            if (child is TFrameworkElement frameworkElement)
            {
                return frameworkElement;
            }
            else
            {
                if (GetChild<TFrameworkElement>(child) is TFrameworkElement grandChild)
                {
                    return grandChild;
                }
            }
        }
        return null;
    }
