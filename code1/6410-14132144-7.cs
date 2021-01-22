    enum NodeType { Bob, Jill, Marko, Default }
    interface INode
    {
        NodeType Node { get; };
    }
        
    class Bob : INode
    {
        public NodeType Node { get { return NodeType.Bob; } }
    }
    class Jill : INode
    {
        public NodeType Node { get { return NodeType.Jill; } }
    }
    class Marko : INode
    {
        public NodeType Node { get { return NodeType.Marko; } }
    }
    //Your function:
    void Do(INode childNode)
    {
        switch(childNode.Node)
        {
            case Bob:
              break;
            case Jill:
              break;
            case Marko:
              break;
            Default:
              throw new ArgumentException();
        }
    }
