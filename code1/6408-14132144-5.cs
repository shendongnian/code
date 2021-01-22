    enum NodeType { Bob, Jill, Marko, Default }
    interface INode
    {
        NodeType Node { get; };
    }
        
    class Bob
    {
        public NodeType Node { get { return NodeType.Bob; } }
    }
    class Jill
    {
        public NodeType Node { get { return NodeType.Jill; } }
    }
    class Marko
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
