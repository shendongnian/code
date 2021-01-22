    public interface IHaveChildren 
    {
        string ParentType { get; }
        int ParentId { get; }
    }
    public interface IChildIterator
    {
        IEnumerable<IChild> GetChildren();
    }
    
    public void DefaultChildIterator : IChildIterator
    {
        private readonly IHaveChildren _parent;
        public DefaultChildIterator(IHaveChildren parent)
        {
            _parent = parent; 
        }
        public IEnumerable<IChild> GetChildren() 
        { 
            // default child iterator impl
        }
    }
    public Node : IHaveChildren, IChildIterator
    { 
        // *snip*
        public IEnumerable<IChild> GetChildren()
        {
            return new DefaultChildIterator(this).GetChildren();
        }
    }
