    private async void treeview1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        var control = await CreateControlAsync(e.Node);
        if (e.Node.Equals(treeview1.SelectedNode)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(control);
        }
        else
        {
            control.Dispose();
        }
    }
    private async Control CreateControlAsync(TreeNode node)
    {
        return await Task.Factory.StartNew(() => CreateControl(node), ApartmentState.STA);
    }
    private Control CreateControl(TreeNode node)
    {
        // return some control which takes some time to create
    }
