    public void ValidateStructure()
    {
        Node root = // get the root node
        try
        {
            ValidateChildren(root);
            Console.WriteLine("All nodes are valid");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Structure contained a null node.");
        }
        
    }
    public void ValidateChildren(Node parent)
    {
        // an NullReferenceException would be raised here since parent would be null 
        foreach (var child in parent.Children)
        {
            ValidateChildren(child);
        }
    }
