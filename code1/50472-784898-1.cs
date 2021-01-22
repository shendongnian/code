    private ItemType CloneDeep(ItemType node)
    {
        ItemType clone = new ItemType();
        clone.Property1 = node.Property1;
        clone.Property2 = node.Property2;
    
        foreach ( ItemType child in node.Nodes)
        {
            clone.Nodes.add(CloneDeep(child));
        }
        return clone;
    }
