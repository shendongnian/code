    private void TreeViewItem_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            if (TreeView.SelectedItem != null)
            {
                DragDrop.DoDragDrop(this,
                    TreeView.ItemContainerGenerator.ContainerFromItem(TreeView.SelectedItem) as TreeViewItem,
                    DragDropEffects.Move);
            }
        }
    }
