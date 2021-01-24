    int selectedIndex = statements.FindIndex(f => f.IsCurrentFocussed);
    int searchPos = (selectedIndex + 1) % statements.Count;
    while (searchPos != selectedIndex)
    {
        if (statement.TestsFailed == 1 && !statement.IsSearched)
        {
            statements.ForEach(f => { f.IsCurrentFocused = false; });
            statement.IsCurrentFocused = true;
            statement.IsSearched = true;
            TreeViewItem item = GetTreeViewItem(ViewTestDataTree, statement);
            item.IsExpanded = true;
            return;
        }
        searchPos = (selectedIndex + 1) % statements.Count;
    }
