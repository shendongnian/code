    if (string.IsNullOrWhiteSpace(Properties.Settings.Default.SelectedTreeNode))
    {                
        Properties.Settings.Default.SelectedTreeNode = SerializeNode(treeView.SelectedNode);
        Properties.Settings.Default.Save();
    }
