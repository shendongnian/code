    bool dblClick;
    
    private void treeView_MouseDown(object sender, MouseEventArgs e)
    {
      dblClick = e.Button == MouseButtons.Left && e.Clicks == 2;
    }
    
    private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
      if (e.Action == TreeViewAction.Expand) e.Cancel = dblClick;
    }
