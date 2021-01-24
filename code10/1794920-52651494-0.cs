    // ...
    if (found == "")
    {
        Node myparentNode = new Node(targetNode.Parent.Id);
        return getRecursiveNodePropertyParent(myparentNode, alias);
     // ^^^^^^
    }
    else
    {
        return Int32.Parse(targetNode.Id.ToString());
    }
