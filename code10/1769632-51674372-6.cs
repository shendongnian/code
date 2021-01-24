    private Node[] nodes;
    public Node[] Nodes {
        get { return nodes ?? (nodes = new Node[] { }); }
        set { nodes = value; }
    }
