    public sealed class BinarySearchTree<T> : IEnumerable<T>
    {
       private readonly IComparer<T> _comparer;
       public BinaryTreeNode<T> Root { get; private set; }
    
       public BinarySearchTree()
       {    
       }
    
       public BinarySearchTree(IEnumerable<T> collection) : 
           this(collection, Comparer<T>.Default)
       {
       }
    
       public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer)
       {
           if (collection == null) throw new ArgumentNullException("collection");
           if (comparer == null) throw new ArgumentNullException("comparer");
    
           _comparer = comparer;
           foreach (var item in collection)
               Add(item);
       }
    
       public BinarySearchTree(BinaryTreeNode<T> root)
       {
           Root = root;
       }
    
       public void Add(T val)	
       {	
           var newNode = new BinaryTreeNode<T>(val);
           if (Root == null)
           {
               Root = newNode;
               return;
           }
    
           Add(Root, newNode);	
       }
    
       void Add(BinaryTreeNode<T> root, BinaryTreeNode<T> node)
       {
           if (_comparer.Compare(node.Value, root.Value) <= 0)
           {
               if (root.Left == null)
                   root.Left = node;
               else
                   Add(root.Left, node);
           }
           else //node.Value > root.Value
           {
               if (root.Right == null)
                   root.Right = node;
               else
                   Add(root.Right, node);	
           }
       }
    
       public bool Contains(T val)
       {
           return Contains(Root, val);
       }
    
       bool Contains(BinaryTreeNode<T> node, T val)
       {
           if (node == null) 
               return false;
    	
           var comparison = _comparer.Compare(val, node.Value);
           if (comparison == 0) //val = node.value
               return true;
           else if (comparison < 0) //val < node.Value
               return Contains(node.Left, val);
           else //val > node.Value
               return Contains(node.Right, val);
       }
    
       public T GetMinimum()
       {
           if (Root == null)
               return default(T);
    
           var node = Root;
           while (node.Left != null)
               node = node.Left;
    
           return node.Value;		
       }
    
       public T GetMaximum()
       {
           if (Root == null)
               return default(T);
    
           var node = Root;
           while (node.Right != null)
               node = node.Right;
    
           return node.Value;		
       }
       public IEnumerator<T> GetEnumerator()
       {
           return new BinaryTreeEnumerator<T>(Root);
       }
       IEnumerator IEnumerable.GetEnumerator()
       {
           return GetEnumerator();
       }
    }
    	
    public sealed class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Left {get; set;}
        public BinaryTreeNode<T> Right {get; set;}		
        public T Value {get; private set;}
    
        public BinaryTreeNode(T val)
        {
            Value = val;
        }
    }
    public sealed class BinaryTreeEnumerator<T> : IEnumerator<T>
    {
        private Stack<BinaryTreeNode<T>> _stack = new Stack<BinaryTreeNode<T>>();
        public T Current { get; private set; }
        public BinaryTreeEnumerator(BinaryTreeNode<T> root)
        {
            if (root == null)
                return; //empty root = Enumerable.Empty<T>()
            PushLeftBranch(root);
        }
        public void Dispose()
        {
            _stack = null; //help GC
        }
        public bool MoveNext()
        {
            if (_stack.Count == 0)
                return false;
            var node = _stack.Pop();
            Current = node.Value;
            if (node.Right != null)
                PushLeftBranch(node.Right);
            return true;
        }
        private void PushLeftBranch(BinaryTreeNode<T> node)
        {
            while (node != null)
            {
                _stack.Push(node);
                node = node.Left;
            }
        }
        public void Reset()
        {
            _stack.Clear();
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
