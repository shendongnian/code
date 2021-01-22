    private void tvXML_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (tvXML.SelectedNode is MyTreeNode)
        {
           MyTreeNode selectedNode = tvXML.SelectedNode as MyTreeNode; 
           selectedNode.list.Add(.., ..);
        }
        if (e.Node is MyTreeNode)
        {
           MyTreeNode node = e.Node as MyTreeNode; 
           node.list.Add(.., ..);
        }
    }
