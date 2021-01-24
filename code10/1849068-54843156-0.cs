    public interface IRoot<TChild>
    {
        IReadOnlyList<TChild> Children { get; }
        void AddChild(TChild child);
    }
    public interface ILeaf<TParent>
    {
        TParent Parent { get; }
    }
    public interface INode<TParent, TChild> : IRoot<TChild>, ILeaf<TParent>
    {
    }
