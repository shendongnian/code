    TreeNode tn = new TreeNode();
    tn.Text = "NewRecord";
    tn.ImageIndex = 1;
    
    treeView.SelectedNode.Nodes.Add(tn);
    treeView.SelectedNode = tn;
    treeView.SelectedNode.SelectedImageIndex = tn.ImageIndex; // <--- Problem solved
    tn.BeginEdit();
