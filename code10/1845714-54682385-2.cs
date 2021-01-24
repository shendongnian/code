    protected void Save_Click(object sender, EventArgs e)
    {
        List<string> checkNodes = new List<string>();
        List<string> unCheckNodes = new List<string>();
        GetCheckUncheckTreeNodes(TreeView1.Nodes, ref checkNodes, ref unCheckNodes);
    }
    private void GetCheckUncheckTreeNodes(TreeNodeCollection nodeCollection, ref List<string>checkNodes, ref List<string> unCheckNodes)
    {
        foreach (TreeNode node in nodeCollection)
        {
            if (node.Checked)
                checkNodes.Add(node.Text);
            else unCheckNodes.Add(node.Text);
            if (node.ChildNodes.Count > 0)
                GetCheckUncheckTreeNodes(node.ChildNodes, ref checkNodes, ref unCheckNodes);
        }
    }
    
