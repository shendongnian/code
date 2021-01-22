    enum NodeType { Bob, Jill, Marko, Default }
    interface INode
    {
        NodeType Node;
    }
        
    class Bob
    {
        public NodeType { get { return NodeType.Bob; } }
    }
    class Jill
    {
        public NodeType { get { return NodeType.Jill; } }
    }
    class Marko
    {
        public NodeType { get { return NodeType.Marko; } }
    }
    //Your function:
    void Do(INode childNode)
    {
        switch(childNode.NodeType)
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
