    public static DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached(
        "IsFocused",
        typeof(bool),
        typeof(TextBoxProperties),
        new UIPropertyMetadata(false,OnIsFocusedChanged)
    );
    
    public static bool GetIsFocused(DependencyObject dependencyObject) {
        return (bool)dependencyObject.GetValue(IsFocusedProperty);
    }
    
    public static void SetIsFocused(DependencyObject dependencyObject, bool value) {
        dependencyObject.SetValue(IsFocusedProperty, value);
    }
