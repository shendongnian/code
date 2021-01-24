    public abstract class BaseTree<TNode>
        where TNode : BaseNode // TNode must be at least (base class) a BaseNode
    {
        public TNode Node { get; set; } // Can be a collection as well, depending on your needs
        public void DoStuff()
        {
            // Node is a BaseNode
        }
    }
    public class RedBlackTree : BaseTree<RedBlackNode>
    {
        public void DoMoreStuff()
        {
            // Node is a RedBlackNode
        }
    }
    public abstract class BaseNode
    {
    }
    public class RedBlackNode : BaseNode
    {
    }
