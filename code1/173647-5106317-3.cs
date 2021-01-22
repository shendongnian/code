private void TreeViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
{
    // skip mouse clicks on the expander button
    if (e.Source is ToggleButton)
        return;
    // find the original source's parent TreeViewItem
    DependencyObject originalSource = e.OriginalSource as DependencyObject;
    while (originalSource != null)
    {
        TreeViewItem tvi = originalSource as TreeViewItem;
        if (tvi != null)
        {
            IListItem listItem = tvi.Header as IListItem;
            if (listItem != null)
            {
                if (Keyboard.Modifiers == ModifierKeys.Shift)
                    ViewModel.MultiSelectTo(listItem);
                else if (Keyboard.Modifiers == ModifierKeys.Control)
                    ViewModel.ToggleSelection(listItem);
                else
                    ViewModel.Select(listItem);
            }
            // the TreeViewItem is never truly selected... when selected, we manually change it's background color (see xaml)
            tvi.IsSelected = false;
            e.Handled = true;
            break;
        }
        originalSource = VisualTreeHelper.GetParent(originalSource);
    }
}
