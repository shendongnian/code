    private List<object> _nodes;    // private backing field
    public List<object> Nodes
    {
        get
        {
            return _nodes;          // can be "gotten" by any class
        }
    
        private set                 // can only be set from within this class
        {
            if (value != _nodes)
            {
                // do additional logic
    
                _nodes = value; // set the backing variable
            }
        }
    }
    
    public void AddNode(object Node)
    {
        Nodes.Add(Node);
    }
    
    public void RemoveNode(object Node)
    {
        Nodes.Remove(Node);
    }
