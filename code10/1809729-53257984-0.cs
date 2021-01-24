    public static class VerifiableBehaviour
    {
        public static bool GetVerified(UIElement obj) => (bool)obj.GetValue(VerifiedProperty);
        public static void SetVerified(DependencyObject obj, bool value) => obj.SetValue(VerifiedProperty, value);
        public static readonly DependencyProperty VerifiedProperty = DependencyProperty.RegisterAttached(
            "Verified", typeof(bool), typeof(VerifiableBehaviour),
            new FrameworkPropertyMetadata(false)
            {
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            });
        public static bool GetTracking(UIElement obj) => (bool)obj.GetValue(TrackingProperty);
        public static void SetTracking(UIElement obj, bool value) => obj.SetValue(TrackingProperty, value);
        public static readonly DependencyProperty TrackingProperty = DependencyProperty.RegisterAttached(
            "Tracking", typeof(bool), typeof(VerifiableBehaviour),
            new PropertyMetadata(false, Tracking_PropertyChanged));
        private static void Tracking_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            if ((bool)e.NewValue)
                element.LostFocus += Element_LostFocus;
            else
                element.LostFocus -= Element_LostFocus;
        }
        private static void Element_LostFocus(object sender, RoutedEventArgs e)
        {
            UIElement element = sender as UIElement;
            SetVerified(element, true);
        }
    }
