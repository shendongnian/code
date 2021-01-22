    private void treeControl_AfterCheck(TreeControl tc,
                                                NodeEventArgs e)
    {
      if(e.Node.ForeColor == Color.Gray)
        e.Node.Checked = !e.Node.Checked;
    }
