    private void TreeSetup_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((TreeViewItem)sender).IsSelected = true;
            e.Handled = true;
        }
        private void TreeSetup_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContextMenu PopupMenu = this.FindResource("cmButton") as ContextMenu;
            if (TreeSetup.SelectedItem != null)
            {
                PopupMenu.PlacementTarget = sender as TreeViewItem;
                PopupMenu.IsOpen = true;
            }
        }
