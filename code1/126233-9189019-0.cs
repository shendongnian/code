    public sealed class IgnoreMouseWheelBehavior 
    {
        public static bool GetIgnoreMouseWheel(DataGrid gridItem)
        {
            return (bool)gridItem.GetValue(IgnoreMouseWheelProperty);
        }
        public static void SetIgnoreMouseWheel(DataGrid gridItem, bool value)
        {
            gridItem.SetValue(IgnoreMouseWheelProperty, value);
        }
        public static readonly DependencyProperty IgnoreMouseWheelProperty =
            DependencyProperty.RegisterAttached("IgnoreMouseWheel", typeof(bool),
            typeof(IgnoreMouseWheelBehavior), new UIPropertyMetadata(false, OnIgnoreMouseWheelChanged));
        static void OnIgnoreMouseWheelChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            var item = depObj as DataGrid;
            if (item == null)
                return;
            if (e.NewValue is bool == false)
                return;
            if ((bool)e.NewValue)
                item.PreviewMouseWheel += OnPreviewMouseWheel;
            else
                item.PreviewMouseWheel -= OnPreviewMouseWheel;
        }
        static void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            var e2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                         {RoutedEvent = UIElement.MouseWheelEvent};
            var gv = sender as DataGrid;
            if (gv != null) gv.RaiseEvent(e2);
        }
    }
