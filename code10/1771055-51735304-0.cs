    public static class ToggleButtonInfo
    {
        private static readonly DependencyProperty CheckedBackgroundProperty = DependencyProperty.RegisterAttached("CheckedBackground", typeof(Brush), typeof(ToggleButtonInfo));
        public static void SetCheckedBackground(ToggleButton target, Brush value) => target.SetValue(CheckedBackgroundProperty, value);
        public static Brush GetCheckedBackground(ToggleButton target) => (Brush)target.GetValue(CheckedBackgroundProperty);
    }
