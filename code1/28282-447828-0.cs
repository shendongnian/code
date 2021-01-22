    private void BuildTree()
    {
       List<Item> items = from item in dataContext.Items
                          select item;
    
       List<Item> rootItems = items.FindAll(p => p.ParentID == null );
    
       foreach ( Item item in rootItems )
       {
          TreeViewNode tvi = new TreeViewNode(item.text);
          BuildChildNodes(tvi, items, item.ID);
          YourTreeNodeName.Nodes.Add(tvi);
       }   
    }
    
    private void BuildChildNodes(TreeViewNode parentNode, List<Item> items, long parentID)
    {
       List<Item> children = items.FindAll ( p => p.ParentID = parentID );
       foreach( Item item in children)
       {
          TreeViewNode tvi = new TreeViewNode(item.text);
          parentNode.Nodes.Add(tvi);
          BuildChildNodes(tvi, items, item.ID);         
       }
    }
