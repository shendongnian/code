    public class ControlSettings : DependencyObject
    {
        public static readonly DependencyProperty AccessIndirectPropertyProperty =
            DependencyProperty.RegisterAttached(
                  "AccessIndirectProperty", typeof(bool), typeof(ControlSettings),
                  new PropertyMetadata(false));
        public static bool GetAccessIndirectProperty(DependencyObject d)
        {
            return (bool) d.GetValue(AccessIndirectPropertyProperty);
        }
        public static void SetAccessIndirectProperty(DependencyObject d, bool value)
        {
            d.SetValue(AccessIndirectPropertyProperty, value);
        }
    }
