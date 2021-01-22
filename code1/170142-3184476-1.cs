    public Node PopulateTree(TreeData[] treeData)
    {
        Dictionary<{IdType}, Node> flattenedTree = new Dictionary<{IdType}, Node>();
         foreach(TreeData data in treeData)
         {
             Node node = new Node();
             if (data.ParentId != {EmptyId})
             {
                 Node parentNode = flattenedTree[data.ParentId];
                 parentNode.Add(node);
             }
             flattenedTree.Add(data.Id, node);
         }
    }
