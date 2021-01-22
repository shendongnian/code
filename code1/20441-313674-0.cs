    private void /*TreeNode*/ RecursiveAdd(OntologyNode on, TreeNode tn)
    {
        if (on.Children.Count == 0)
        {
            return;             
        }
        foreach (OntologyNode child in on.Children)
        {
            TreeNode tCur = tn.Nodes.Add(child.Name);
            tCur.Tag = child;//optional for some selected node events
            RecursiveAdd(child, tCur);               
        }
     }
