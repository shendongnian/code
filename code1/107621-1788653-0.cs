    internal delegate void TreeWalkAction<Key, Value>(BinaryTreeSearch<Key, Value>.Node node);
    internal delegate bool TreeWalkTerminationPredicate<Key, Value>(BinaryTreeSearch<Key, Value>.Node node);
    internal class BinaryTreeSearch<Key, Value>
    {
        // Fields
        private IComparer<Key> comparer;
        private int count;
        private Node root;
        private int version;
        // Methods
        public BinaryTreeSearch(IComparer<Key> comparer)
        {
            if (comparer == null)
            {
                this.comparer = Comparer<Key>.Default;
            }
            else
            {
                this.comparer = comparer;
            }
        }
        private Node First
        {
            get
            {
                if (root == null) return null;
                Node n = root;
                while (n.Left != null)
                {
                    n = n.Left;
                }
                return n;
            }
        }
        public Key Min
        {
            get
            {
                Node first = First;
                return first == null ? default(Key) : first.Key;
            }
        }
        public Key Max
        {
            get
            {
                if (root == null) return default(Key);
                Node n = root;
                while (n.Right != null)
                {
                    n = n.Right;
                }
                return n.Key;
            }
        }
        public List<Value> this[Key key]
        {
            get
            {
                Node n = FindNode(key);
                return n == null ? new List<Value>() : n.Values;
            }
        }
        public List<Value> GetRange(Key start, Key end)
        {
            Node node = FindNextNode(start);
            List<Value> ret = new List<Value>();
            InOrderTreeWalk(node, 
                aNode => ret.AddRange(aNode.Values),
                aNode => comparer.Compare(end, aNode.Key) < 0);
            return ret;
        }
        public void Add(Key key, Value value)
        {
            if (this.root == null)
            {
                this.root = new Node(null, key, value, false);
                this.count = 1;
            }
            else
            {
                Node root = this.root;
                Node node = null;
                Node grandParent = null;
                Node greatGrandParent = null;
                int num = 0;
                while (root != null)
                {
                    num = this.comparer.Compare(key, root.Key);
                    if (num == 0)
                    {
                        root.Values.Add(value);
                        count++;
                        return;
                    }
                    if (Is4Node(root))
                    {
                        Split4Node(root);
                        if (IsRed(node))
                        {
                            this.InsertionBalance(root, ref node, grandParent, greatGrandParent);
                        }
                    }
                    greatGrandParent = grandParent;
                    grandParent = node;
                    node = root;
                    root = (num < 0) ? root.Left : root.Right;
                }
                Node current = new Node(node, key, value);
                if (num > 0)
                {
                    node.Right = current;
                }
                else
                {
                    node.Left = current;
                }
                if (node.IsRed)
                {
                    this.InsertionBalance(current, ref node, grandParent, greatGrandParent);
                }
                this.root.IsRed = false;
                this.count++;
                this.version++;
            }
        }
        public void Clear()
        {
            this.root = null;
            this.count = 0;
            this.version++;
        }
        public bool Contains(Key key)
        {
            return (this.FindNode(key) != null);
        }
        internal Node FindNode(Key item)
        {
            int num;
            for (Node node = this.root; node != null; node = (num < 0) ? node.Left : node.Right)
            {
                num = this.comparer.Compare(item, node.Key);
                if (num == 0)
                {
                    return node;
                }
            }
            return null;
        }
        internal Node FindNextNode(Key key)
        {
            int num;
            Node node = root;
            while (true)
            {
                num = comparer.Compare(key, node.Key);
                if (num == 0)
                {
                    return node;
                }
                else if (num < 0)
                {
                    if (node.Left == null) return node;
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }
        }
        private static Node GetSibling(Node node, Node parent)
        {
            if (parent.Left == node)
            {
                return parent.Right;
            }
            return parent.Left;
        }
        internal void InOrderTreeWalk(Node start, TreeWalkAction<Key, Value> action, TreeWalkTerminationPredicate<Key, Value> terminationPredicate)
        {
            Node node = start;
            while (node != null && !terminationPredicate(node))
            {
                action(node);
                node = node.Next;
            }
        }
        private void InsertionBalance(Node current, ref Node parent, Node grandParent, Node greatGrandParent)
        {
            Node node;
            bool flag = grandParent.Right == parent;
            bool flag2 = parent.Right == current;
            if (flag == flag2)
            {
                node = flag2 ? RotateLeft(grandParent) : RotateRight(grandParent);
            }
            else
            {
                node = flag2 ? RotateLeftRight(grandParent) : RotateRightLeft(grandParent);
                parent = greatGrandParent;
            }
            grandParent.IsRed = true;
            node.IsRed = false;
            this.ReplaceChildOfNodeOrRoot(greatGrandParent, grandParent, node);
        }
        private static bool Is2Node(Node node)
        {
            return ((IsBlack(node) && IsNullOrBlack(node.Left)) && IsNullOrBlack(node.Right));
        }
        private static bool Is4Node(Node node)
        {
            return (IsRed(node.Left) && IsRed(node.Right));
        }
        private static bool IsBlack(Node node)
        {
            return ((node != null) && !node.IsRed);
        }
        private static bool IsNullOrBlack(Node node)
        {
            if (node != null)
            {
                return !node.IsRed;
            }
            return true;
        }
        private static bool IsRed(Node node)
        {
            return ((node != null) && node.IsRed);
        }
        private static void Merge2Nodes(Node parent, Node child1, Node child2)
        {
            parent.IsRed = false;
            child1.IsRed = true;
            child2.IsRed = true;
        }
        public bool Remove(Key key, Value value)
        {
            if (this.root == null)
            {
                return false;
            }
            Node root = this.root;
            Node parent = null;
            Node node3 = null;
            Node match = null;
            Node parentOfMatch = null;
            bool flag = false;
            while (root != null)
            {
                if (Is2Node(root))
                {
                    if (parent == null)
                    {
                        root.IsRed = true;
                    }
                    else
                    {
                        Node sibling = GetSibling(root, parent);
                        if (sibling.IsRed)
                        {
                            if (parent.Right == sibling)
                            {
                                RotateLeft(parent);
                            }
                            else
                            {
                                RotateRight(parent);
                            }
                            parent.IsRed = true;
                            sibling.IsRed = false;
                            this.ReplaceChildOfNodeOrRoot(node3, parent, sibling);
                            node3 = sibling;
                            if (parent == match)
                            {
                                parentOfMatch = sibling;
                            }
                            sibling = (parent.Left == root) ? parent.Right : parent.Left;
                        }
                        if (Is2Node(sibling))
                        {
                            Merge2Nodes(parent, root, sibling);
                        }
                        else
                        {
                            TreeRotation rotation = RotationNeeded(parent, root, sibling);
                            Node newChild = null;
                            switch (rotation)
                            {
                                case TreeRotation.LeftRotation:
                                    sibling.Right.IsRed = false;
                                    newChild = RotateLeft(parent);
                                    break;
                                case TreeRotation.RightRotation:
                                    sibling.Left.IsRed = false;
                                    newChild = RotateRight(parent);
                                    break;
                                case TreeRotation.RightLeftRotation:
                                    newChild = RotateRightLeft(parent);
                                    break;
                                case TreeRotation.LeftRightRotation:
                                    newChild = RotateLeftRight(parent);
                                    break;
                            }
                            newChild.IsRed = parent.IsRed;
                            parent.IsRed = false;
                            root.IsRed = true;
                            this.ReplaceChildOfNodeOrRoot(node3, parent, newChild);
                            if (parent == match)
                            {
                                parentOfMatch = newChild;
                            }
                            node3 = newChild;
                        }
                    }
                }
                int num = flag ? -1 : this.comparer.Compare(key, root.Key);
                if (num == 0)
                {
                    flag = true;
                    match = root;
                    parentOfMatch = parent;
                }
                node3 = parent;
                parent = root;
                if (num < 0)
                {
                    root = root.Left;
                }
                else
                {
                    root = root.Right;
                }
            }
            if (match != null)
            {
                if (match.Values.Remove(value))
                {
                    this.count--;
                }
                if (match.Values.Count == 0)
                {
                    this.ReplaceNode(match, parentOfMatch, parent, node3);
                }
                
            }
            if (this.root != null)
            {
                this.root.IsRed = false;
            }
            this.version++;
            return flag;
        }
        private void ReplaceChildOfNodeOrRoot(Node parent, Node child, Node newChild)
        {
            if (parent != null)
            {
                if (parent.Left == child)
                {
                    parent.Left = newChild; 
                }
                else
                {
                    parent.Right = newChild; 
                }
                if (newChild != null) newChild.Parent = parent;
            }
            else
            {
                this.root = newChild;
            }
        }
        private void ReplaceNode(Node match, Node parentOfMatch, Node succesor, Node parentOfSuccesor)
        {
            if (succesor == match)
            {
                succesor = match.Left;
            }
            else
            {
                if (succesor.Right != null)
                {
                    succesor.Right.IsRed = false;
                }
                if (parentOfSuccesor != match)
                {
                    parentOfSuccesor.Left = succesor.Right; if (succesor.Right != null) succesor.Right.Parent = parentOfSuccesor;
                    succesor.Right = match.Right; if (match.Right != null) match.Right.Parent = succesor;
                }
                succesor.Left = match.Left; if (match.Left != null) match.Left.Parent = succesor;
            }
            if (succesor != null)
            {
                succesor.IsRed = match.IsRed;
            }
            this.ReplaceChildOfNodeOrRoot(parentOfMatch, match, succesor);
        }
        private static Node RotateLeft(Node node)
        {
            Node right = node.Right;
            node.Right = right.Left; if (right.Left != null) right.Left.Parent = node;
            right.Left = node; if (node != null) node.Parent = right;
            return right;
        }
        private static Node RotateLeftRight(Node node)
        {
            Node left = node.Left;
            Node right = left.Right;
            node.Left = right.Right; if (right.Right != null) right.Right.Parent = node;
            right.Right = node; if (node != null) node.Parent = right;
            left.Right = right.Left; if (right.Left != null) right.Left.Parent = left;
            right.Left = left; if (left != null) left.Parent = right;
            return right;
        }
        private static Node RotateRight(Node node)
        {
            Node left = node.Left;
            node.Left = left.Right; if (left.Right != null) left.Right.Parent = node;
            left.Right = node; if (node != null) node.Parent = left;
            return left;
        }
        private static Node RotateRightLeft(Node node)
        {
            Node right = node.Right;
            Node left = right.Left;
            node.Right = left.Left; if (left.Left != null) left.Left.Parent = node;
            left.Left = node; if (node != null) node.Parent = left;
            right.Left = left.Right; if (left.Right != null) left.Right.Parent = right;
            left.Right = right; if (right != null) right.Parent = left;
            return left;
        }
        private static TreeRotation RotationNeeded(Node parent, Node current, Node sibling)
        {
            if (IsRed(sibling.Left))
            {
                if (parent.Left == current)
                {
                    return TreeRotation.RightLeftRotation;
                }
                return TreeRotation.RightRotation;
            }
            if (parent.Left == current)
            {
                return TreeRotation.LeftRotation;
            }
            return TreeRotation.LeftRightRotation;
        }
        private static void Split4Node(Node node)
        {
            node.IsRed = true;
            node.Left.IsRed = false;
            node.Right.IsRed = false;
        }
        // Properties
        public IComparer<Key> Comparer
        {
            get
            {
                return this.comparer;
            }
        }
        public int Count
        {
            get
            {
                return this.count;
            }
        }
        internal class Node
        {
            // Fields
            private bool isRed;
            private Node left, right, parent;
            private Key key;
            private List<Value> values;
            // Methods
            public Node(Node parent, Key item, Value value) : this(parent, item, value, true)
            {
            }
            public Node(Node parent, Key key, Value value, bool isRed)
            {
                this.key = key;
                this.parent = parent;
                this.values = new List<Value>(new Value[] { value });
                this.isRed = isRed;
            }
            // Properties
            public bool IsRed
            {
                get
                {
                    return this.isRed;
                }
                set
                {
                    this.isRed = value;
                }
            }
            public Key Key
            {
                get
                {
                    return this.key;
                }
                set
                {
                    this.key = value;
                }
            }
            public List<Value> Values { get { return values; } }
            public Node Left
            {
                get
                {
                    return this.left;
                }
                set
                {
                    this.left = value;
                }
            }
            public Node Right
            {
                get
                {
                    return this.right;
                }
                set
                {
                    this.right = value;
                }
            }
            public Node Parent
            {
                get
                {
                    return this.parent;
                }
                set
                {
                    this.parent = value;
                }
            }
            public Node Next
            {
                get
                {
                    if (right == null)
                    {
                        if (parent == null)
                        {
                            return null; // this puppy must be lonely
                        }
                        else if (parent.Left == this) // this is a left child
                        {
                            return parent;
                        }
                        else
                        {
                            //this is a right child, we need to go up the tree
                            //until we find a left child.  Then the parent will be the next
                            Node n = this;
                            do
                            {
                                n = n.parent;
                                if (n.parent == null)
                                {
                                    return null; // this must have been a node along the right edge of the tree  
                                }
                            } while (n.parent.right == n);
                            return n.parent;
                        }
                    }
                    else // there is a right child.
                    {
                        Node go = right;
                        while (go.left != null)
                        {
                            go = go.left;
                        }
                        return go;
                    }
                }
            }
            public override string ToString()
            {
                return key.ToString() + " - [" + string.Join(", ", new List<string>(values.Select<Value, string>(o => o.ToString())).ToArray()) + "]";
            }
        }
        internal enum TreeRotation
        {
            LeftRightRotation = 4,
            LeftRotation = 1,
            RightLeftRotation = 3,
            RightRotation = 2
        }
    }
