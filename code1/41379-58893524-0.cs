    public static class SelectListBoxItemWhenControlInsideTheItemIsClickedBehavior
    {
        public static readonly DependencyProperty EnableProperty = DependencyProperty.RegisterAttached(
            "Enable",
            typeof(bool),
            typeof(SelectListBoxItemWhenControlInsideTheItemIsClickedBehavior),
            new FrameworkPropertyMetadata(false, OnEnableChanged));
    
    
        public static bool GetEnable(FrameworkElement frameworkElement)
        {
            return (bool)frameworkElement.GetValue(EnableProperty);
        }
    
    
        public static void SetEnable(FrameworkElement frameworkElement, bool value)
        {
            frameworkElement.SetValue(EnableProperty, value);
        }
    
    
        private static void OnEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listBoxItem = (ListBoxItem)d;
    
            if (listBoxItem == null)
                return;
    
            listBoxItem.PreviewGotKeyboardFocus += ListBoxItem_PreviewGotKeyboardFocus;
        }
    
        private static void ListBoxItem_PreviewGotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            var listBoxItem = (ListBoxItem)sender;
            listBoxItem.IsSelected = true;
        }
    }
