    protected void Save_Click(object sender, EventArgs e)
    {
        List<string> checkNodes = new List<string>();
        List<string> unCheckNodes = new List<string>();
        foreach (TreeNode node in TreeView1.Nodes)
        {
            if (node.Checked) 
                checkNodes.Add(node.Text);
            else unCheckNodes.Add(node.Text);
        }
    }
