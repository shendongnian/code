    private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
        treeView1.BeginInvoke(new Action(treeView1.Sort));
    }
    
    
    private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
        treeView1.BeginInvoke(new MethodInvoker(treeView1.Sort));
    }
