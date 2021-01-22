    TreeViewItem folderNode = new TreeViewItem { Header = Path.GetFileName(folderPath) };
    parentNode.Items.Add(folderNode);
    // create the dummy item under it
    TreeViewItem dummy = new TreeViewItem { Tag = _dummyTag };
    folderNode.Items.Add(dummy);
    folderNode.Expanded += delegate
        {
            if (folderNode.Items.Count == 1)
            {
                if (((TreeViewItem)folderNode.Items[0]).Tag == _dummyTag)
                {
                    folderNode.Items.Clear();
                    CreateFolderChildren(folderNode, folderPath);
                }
            }
        };
