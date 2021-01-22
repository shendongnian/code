    public static void Show(this UIElement element)
    {
        element.Visibility = Visibility.Visible;
    }
    
    public static void Hide(this UIElement element)
    {
        element.Visibility = Visibility.Collapsed;
    }
