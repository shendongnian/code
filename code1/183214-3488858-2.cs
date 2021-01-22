    public interface INode { public INode Parent { get; } }
    public interface IElement : INode { public Dictionary<string, string> Attributes { get; } }
    public interface IDocument : IElement { ... }
    public interface IExtraNode : INode { public int Priority { get; } }
    public interface IExtraElement : IExtraNode, IElement { }
    public interface IExtraDocument : IExtraElement, IDocument { ... }
