    public abstract class ZooNode
    {
        public ZooNode Parent { get; set; }
        public virtual IList<ZooNode> Children { get; set; }
    }
