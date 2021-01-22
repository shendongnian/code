    public static class FrameworkElementExtensions
    {
        // usage xPanel.SetBackground(SystemColors.DesktopBrushKey);
        public static void SetBackground(this Panel panel, ResourceKey key)
        {
            panel.SetResourceReference(Panel.BackgroundProperty, key);
        }
        // usage xControl.SetBackground(SystemColors.DesktopBrushKey);
        public static void SetBackground(this Control control, ResourceKey key)
        {
            control.SetResourceReference(Control.BackgroundProperty, key);
        }
    }
