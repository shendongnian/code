    public sealed class EventFocusAttachment
    {
        public static UIElement GetTarget(ButtonBase b) => (UIElement)b.GetValue(TargetProperty);
        public static void SetTarget(ButtonBase b, UIElement tgt) => b.SetValue(TargetProperty, tgt);
        public static readonly DependencyProperty TargetProperty = DependencyProperty.RegisterAttached(
                "Target",
                typeof(UIElement),
                typeof(EventFocusAttachment),
                new UIPropertyMetadata(null, (b, _) => (b as ButtonBase)?.AddHandler(
                    ButtonBase.ClickEvent,
                    new RoutedEventHandler((bb, __) => GetTarget((ButtonBase)bb)?.Focus()))));
    };
