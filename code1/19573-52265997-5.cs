    public static class ListBoxEx
    {
        private static DependencyProperty ToggleSelectionProperty = DependencyProperty.RegisterAttached(..., HandleToggleSelectionChanged);
        private static bool GetToggleSelection (DependencyObject obj) => (bool)obj.GetValue(ToggleSelectionProperty);
        private static void SetToggleSelection (DependencyObject obj, bool shouldToggle) => obj.SetValue(ToggleSelectionProperty, shouldToggle);
        private static void HandleToggleSelectionChanged (DependencyObject obj)
        {
            if (obj is ListBox listBoxObj)
            {
               bool shouldToggle = GetToggleSelection(obj);
               if (shouldToggle)
               {
                   listBoxObj.PreviewMouseLeftButtonDown += ToggleListBox_OnPreviewMouseLeftButtonDown ;
               }
               else
               {
                   listBoxObj.PreviewMouseLeftButtonDown -= ToggleListBox_OnPreviewMouseLeftButtonDown ;
               }
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
