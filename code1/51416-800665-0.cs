    private bool treeViewWasNewlyFocused = false;
    
    private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
        if(treeViewWasNewlyFocused)
        {
            e.Cancel = true;
            treeViewWasNewlyFocused = false;
        }
    }
    
    private void TreeView1_GotFocus(object sender, EventArgs e)
    {
        treeViewWasNewlyFocused = true;
    }
