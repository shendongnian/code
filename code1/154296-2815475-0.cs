    public interface INode
    {
        IEnumerable<INode> Children { get; }
        IDataNode<DataType> FindNode<DataType>(DataType value);
        void AddChild(INode node);
    }
    public interface IDataNode<DataType> : INode
    {
        DataType Data { get; }
    }
