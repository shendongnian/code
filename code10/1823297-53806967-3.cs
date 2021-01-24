    public abstract partial class HierarchicalNode<TItem, THierarchicalNode>
        where THierarchicalNode : HierarchicalNode<TItem, THierarchicalNode>, new()
    {
        public IDictionary<string, THierarchicalNode> Children { get; private set; }
        public ICollection<TItem> Items { get; private set; }
        public HierarchicalNode()
        {
            this.Children = new Dictionary<string, THierarchicalNode>();
            this.Items = new List<TItem>();
        }
    }
