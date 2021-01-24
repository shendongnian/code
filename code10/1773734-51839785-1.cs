    public abstract class BaseTree<TNode>
        where TNode : BaseNode // TNode must be at least (base class) a BaseNode
    {
        // Can be a collection as well, depending on your needs
        public TNode Node { get; set; }
        public void DoStuff()
        {
            // Node is a BaseNode
        }
    }
    // Any node in this tree is a RedBlackNode
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
