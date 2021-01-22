    public bool Equals (object obj)
    {
        if (obj is Node)
        {
            return this.Equals(obj as Node);
        }
        return false;
    }
    // your code
    public bool Equals (INode  node)
    {
        return this.name == node.name &&
               this.id = node.id;
    }
