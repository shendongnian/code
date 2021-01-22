    private bool isDoubleClick = false;
    private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
    {
    	if (isDoubleClick && e.Action == TreeViewAction.Collapse)
    		e.Cancel = true;
    }
    
    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
    	if (isDoubleClick && e.Action == TreeViewAction.Expand)
    		e.Cancel = true;
    }
    
    private void treeView1_MouseDown(object sender, MouseEventArgs e)
    {
        isDoubleClick = e.Clicks > 1;
    }
