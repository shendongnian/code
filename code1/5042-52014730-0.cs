    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<string>()
                .Begin("Fastfood")
                    .Begin("Pizza")
                        .Add("Margherita")
                        .Add("Marinara")
                    .End()
                    .Begin("Burger")
                        .Add("Cheese burger")
                        .Add("Chili burger")
                        .Add("Rice burger")
                    .End()
                .End();
            tree.Nodes.ForEach(p => PrintNode(p, 0));
            Console.ReadKey();
        }
        static void PrintNode<T>(TreeNode<T> node, int level)
        {
            Console.WriteLine("{0}{1}", new string(' ', level * 3), node.Value);
            level++;
            node.Children.ForEach(p => PrintNode(p, level));
        }
    }
    public class Tree<T>
    {
        private Stack<TreeNode<T>> m_Stack = new Stack<TreeNode<T>>();
        public List<TreeNode<T>> Nodes { get; } = new List<TreeNode<T>>();
        public Tree<T> Begin(T val)
        {
            if (m_Stack.Count == 0)
            {
                var node = new TreeNode<T>(val, null);
                Nodes.Add(node);
                m_Stack.Push(node);
            }
            else
            {
                var node = m_Stack.Peek().Add(val);
                m_Stack.Push(node);
            }
        
            return this;
        }
        public Tree<T> Add(T val)
        {
            m_Stack.Peek().Add(val);
            return this;
        }
        public Tree<T> End()
        {
            m_Stack.Pop();
            return this;
        }
    }
    public class TreeNode<T>
    {
        public T Value { get; }
        public TreeNode<T> Parent { get; }
        public List<TreeNode<T>> Children { get; }
        public TreeNode(T val, TreeNode<T> parent)
        {
            Value = val;
            Parent = parent;
            Children = new List<TreeNode<T>>();
        }
        public TreeNode<T> Add(T val)
        {
            var node = new TreeNode<T>(val, this);
            Children.Add(node);
            return node;
        }
    }
