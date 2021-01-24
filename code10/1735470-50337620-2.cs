    public static class WindowExt
    {
        public static bool GetShowMaximizeButton(Window obj)
        {
            return (bool)obj.GetValue(ShowMaximizeButtonProperty);
        }
        public static void SetShowMaximizeButton(Window obj, bool value)
        {
            obj.SetValue(ShowMaximizeButtonProperty, value);
        }
        public static readonly DependencyProperty ShowMaximizeButtonProperty =
            DependencyProperty.RegisterAttached("ShowMaximizeButton", typeof(bool), typeof(WindowExt),
                new PropertyMetadata(true));
    }
