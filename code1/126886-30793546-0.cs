    public sealed class EventFocusAttachment
    {
        [DebuggerStepThrough]
        public static UIElement GetTarget(ButtonBase b) { return (UIElement)b.GetValue(TargetProperty); }
        [DebuggerStepThrough]
        public static void SetTarget(ButtonBase b, UIElement target) { b.SetValue(TargetProperty, target); }
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.RegisterAttached("Target",
                                                typeof(UIElement),
                                                typeof(EventFocusAttachment),
                                                new UIPropertyMetadata(null, TargetPropertyChanged));
        public static void TargetPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs _)
        {
            ButtonBase bb;
            if ((bb = o as ButtonBase) != null)
                bb.Click += handler;
        }
        static void handler(Object o, RoutedEventArgs _)
        {
            UIElement target;
            if ((target = GetTarget((ButtonBase)o)) != null)
                target.Focus();
        }
    };
