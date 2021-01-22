    private void ChangeSessionSelection()
    {
        foreach (SessionContainer item in this.treeActiveSessions.Items)
        {
            var treeviewItem = this.treeActiveSessions.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
            if (item.Session == this.selectedSession.Session)
            {
                treeviewItem.IsSelected = true;
                treeviewItem.IsExpanded = true;
            }
            else
            {
                treeviewItem.IsSelected = false;
                treeviewItem.IsExpanded = false;
            }
        }            
    }
