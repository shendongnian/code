    private void exTreeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        if (e.Action != TreeViewAction.Unknown)
        {
            e.Node.Descendants().ToList().ForEach(x =>
            {
                x.Checked = e.Node.Checked;
            });
            e.Node.Ancestors().ToList().ForEach(x =>
            {
                x.Checked = x.Descendants().ToList().Any(y => y.Checked);
            });
        }
    }
