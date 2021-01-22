    [Export("NodeTypes", typeof(INodeType))]
    public SomeNodeType : AbstractNodeType
    {
        public SomeNodeType()
        {
            this.ContextMenu = base.BuildContextMenu(/* ... */);
            /* etc. */
        }
        /* ... other custom logic ... */
    }
