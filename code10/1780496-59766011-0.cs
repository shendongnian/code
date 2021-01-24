    public class AutoExpandBehaviour 
    {
        public static readonly DependencyProperty AutoExpandProperty =
                DependencyProperty.RegisterAttached(
                "AutoExpand",
                typeof(bool),
                typeof(AutoExpandBehaviour),
                new UIPropertyMetadata(false, AutoExpandChanged));
        public static bool GetAutoExpand(Expander expander)
        {
            return (bool)expander.GetValue(AutoExpandProperty);
        }
        public static void SetAutoExpand(Expander expander, bool value)
        {
            expander.SetValue(AutoExpandProperty, value);
        }
        static void AutoExpandChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            var expander = depObj as Expander;
            if (expander == null)
            {
                return;
            }
            if (e.NewValue is bool == false)
                return;
            if ((bool)e.NewValue)
            {
                expander.IsEnabledChanged += Item_IsEnabledChanged;
            }
            else
            {
                expander.IsEnabledChanged -= Item_IsEnabledChanged;
            }
        }
        private static void Item_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var expander = sender as Expander;
            if (expander != null)
            {
                expander.IsExpanded = (bool)e.NewValue;
            }
        }
    }
