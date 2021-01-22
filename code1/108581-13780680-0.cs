    public sealed class BinarySearchTree<T>
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
