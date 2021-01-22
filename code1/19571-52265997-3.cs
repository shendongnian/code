    public static class ListBoxEx
    {
        private static DependencyProperty ToggleSelectionProperty = ...
        private static bool GetToggleSelection (ListBox obj) { ... }
        private static void SetToggleSelection (ListBox obj, bool shouldToggle)
        {
            obj.SetValue(ToggleSelectionProperty, shouldToggle);
            if (shouldToggle)
            {
                obj.PreviewMouseLeftButtonDown += ToggleListBox_OnPreviewMouseLeftButtonDown ;
            }
            else
            {
                obj.PreviewMouseLeftButtonDown -= ToggleListBox_OnPreviewMouseLeftButtonDown ;
            }
        }
    
        private static void ToggleListBox_OnPreviewMouseLeftButtonDown (object sender, MouseButtonEventArgs e)
        {
            // I have a special extension for GetParent, numerous examples on the internet of how you would do that
            var lbi = ((DependencyObject) e.OriginalSource).GetParent<ListBoxItem>();
            if (lbi != null && lbi.IsSelected)
            {
                lbi.IsSelected = false;
                e.Handled = true;
            }
        }
    }
