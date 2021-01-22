    [Export("NodeTypes", typeof(INodeType))]
    public class SomeNodeType : AbstractNodeType
    {
        public SomeNodeType()
        {
            this.ContextMenu = base.BuildContextMenu(/* ... */);
            /* etc. */
        }
        /* ... other custom logic ... */
    }
