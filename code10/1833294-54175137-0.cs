    class BinaryTreeNode<T>
    {
        public readonly T value;
        public BinaryTreeNode<T> left = null;
        public BinaryTreeNode<T> right = null;
        public BinaryTreeNode(T value)
        {
            this.value = value;
        }
        public void InsertValue(T newValue, Comparer<T> comparer)
        {
            InsertValueNR(this, newValue, comparer);
        }
        private static void InsertValueNR(BinaryTreeNode<T> start, T newValue, Comparer<T> comparer)
        {
            for (BinaryTreeNode<T> cur = start; ;)
            {
                int cmp = comparer.Compare(cur.value, newValue);
                if (cmp == 0)
                    throw new InvalidOperationException("value '" + newValue + "' is duplicated in the tree");
                else if (cmp < 0)
                {
                    if (cur.left == null)
                    {
                        cur.left = new BinaryTreeNode<T>(newValue);
                        return;
                    }
                    else
                        cur = cur.left;
                }
                else
                {
                    if (cur.right == null)
                    {
                        cur.right = new BinaryTreeNode<T>(newValue);
                        return;
                    }
                    else
                        cur = cur.right;
                }
            }
        }
        private void InsertValueRecursive(T newValue, Comparer<T> comparer)
        {
            int cmp = comparer.Compare(value, newValue);
            if (cmp == 0)
                throw new InvalidOperationException("value '" + newValue + "' is duplicated in the tree");
            else if (cmp < 0)
            {
                if (left != null)
                    left.InsertValueRecursive(newValue, comparer);
                else
                    left = new BinaryTreeNode<T>(newValue);
            }
            else
            {
                if (right != null)
                    right.InsertValueRecursive(newValue, comparer);
                else
                    right = new BinaryTreeNode<T>(newValue);
            }
        }
        class OrderComparer<T> : Comparer<T>
        {
            private readonly Dictionary<T, int> positions;
            public OrderComparer(List<T> order)
            {
                positions = new Dictionary<T, int>();
                for (int i = 0; i < order.Count; i++)
                {
                    positions[order[i]] = i;
                }
            }
            public override int Compare(T x, T y)
            {
                return -Comparer<int>.Default.Compare(positions[x], positions[y]);
            }
        }
        public static BinaryTreeNode<T> ConstructTree(List<T> preorder, List<T> inorder)
        {
            var comparer = new OrderComparer<T>(inorder);
            var root = new BinaryTreeNode<T>(preorder[0]);
            for (int i = 1; i < preorder.Count; i++)
            {
                root.InsertValue(preorder[i], comparer);
            }
            return root;
        }
        public void PrintPreOrder()
        {
            PreOrder(ch => Console.Write(ch + " "));
            Console.WriteLine();
        }
        public void PrintInOrder()
        {
            InOrder(ch => Console.Write(ch + " "));
            Console.WriteLine();
        }
        public void PreOrder(Action<T> visitor)
        {
            visitor(value);
            if (left != null)
                left.PreOrder(visitor);
            if (right != null)
                right.PreOrder(visitor);
        }
        public void InOrder(Action<T> visitor)
        {
            if (left != null)
                left.InOrder(visitor);
            visitor(value);
            if (right != null)
                right.InOrder(visitor);
        }
    }
