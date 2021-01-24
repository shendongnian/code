    private void exTreeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        if (e.Action != TreeViewAction.Unknown) {
            foreach (TreeNode x in exTreeView1.Descendants(e.Node)) {
                x.Checked = e.Node.Checked;
            }
            foreach (TreeNode x in exTreeView1.Ancestors(e.Node)) {
                bool any = false;
                foreach (TreeNode y in exTreeView1.Descendants(x))
                    any = any || y.Checked;
                x.Checked = any;
            };
        }
    }
