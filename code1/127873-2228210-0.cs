    void TreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
    {
        var IsReadOnly = e.Node.Tag as bool?;
        if (IsReadOnly != null)
        {
            e.Cancel = IsReadOnly.Value;
        }
    }
