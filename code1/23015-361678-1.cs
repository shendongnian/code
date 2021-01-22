    //In Page load
    foreach (DataRow row in topics.Rows)
    {
        TreeNode node = new TreeNode(dr["name"], dr["topicId"])
        node.PopulateOnDemand = true;
         TreeView1.Nodes.Add(node);
     }
     ///
     protected void PopulateNode(Object sender, TreeNodeEventArgs e)
     {
         string topicId = e.Node.Value;
         //select from topic where parentId = topicId.
         foreach (DataRow row in topics.Rows)
         {
             TreeNode node = new TreeNode(dr["name"], dr["topicId"])
             node.PopulateOnDemand = true;
             e.Node.ChildNodes.Add(node);
         }
     }
