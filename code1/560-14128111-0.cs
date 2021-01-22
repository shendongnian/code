    void treeview_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
    	if( e.Button == MouseButtons.Right )
    	{
    		tree.SelectedNode = e.Node;
    	}
    }
