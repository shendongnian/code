    private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
    {`enter code here`
    	if (blnDoubleClick == true && e.Action == TreeViewAction.Collapse)
    		e.Cancel = true;
    }
    
    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
    	if (blnDoubleClick == true && e.Action == TreeViewAction.Expand)
    		e.Cancel = true;
    }
    
    private void treeView1_MouseDown(object sender, MouseEventArgs e)
    {
    	if (e.Clicks > 1)
    		blnDoubleClick = true;
    	else
    		blnDoubleClick = false;
    }
