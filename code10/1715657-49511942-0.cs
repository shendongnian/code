    interface INodeProperties
    {
        string Name { get; set; }
        string Description { get; set; }
    }
    
    class NodeProperties
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
    interface INode
    {
         INodeProperties NodeProps { get; set; }
    }
    
    class Node : INode
    {
         public INodeProperties NodeProps { get; set; } = new NodeProperties();
    }
    
    interface IStructuredNode
    {
          List<Node> Children { get; set; }
    }
    
    class StructuredNode: INode, IStructuredNode
    {
         public INodeProperties NodeProps { get; set; } = new NodeProperties();
         public List<Node> Children { get; set; }
    }
