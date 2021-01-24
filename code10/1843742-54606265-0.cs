    if (inXmlNode.HasChildNodes)
    {
        childNodes = inXmlNode.ChildNodes;
        for (int i = 0; i <= childNodes.Count - 1; i++)
        {
            xNode = childNodes[i];
            inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
            tNode = inTreeNode.Nodes[i];
            AddNode(xNode, tNode);
        }
    }
    else
    {
        inTreeNode.Text = inXmlNode.Name;
    }
