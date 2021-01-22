    public override bool Equals (object obj)
    {
        if (obj is Node)
        {
            return this.Equals(obj as Node);
        }
        return false;
    }
    // your code (modified to take a Node instead of an INode)
    public bool Equals (Node  node)
    {
        return this.name == node.name &&
               this.id = node.id;
    }
