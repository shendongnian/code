        public class NTree<T>
        {
            public T data;
            public LinkedList<NTree<T>> children;
            public NTree(T data)
            {
                this.data = data;
                children = new LinkedList<NTree<T>>();
            }
            public void AddChild(T data)
            {
                var node = new NTree<T>(data) { Parent = this };
                children.AddFirst(node);
            }
            public NTree<T> Parent { get; private set; }
            public NTree<T> GetChild(int i)
            {
                foreach (NTree<T> n in children)
                    if (--i == 0)
                        return n;
                return null;
            }
            public void Traverse(NTree<T> node, TreeVisitor<T> visitor, string t, ref NTree<T> r)
            {
                visitor(node.data, node, t, ref r);
                foreach (NTree<T> kid in node.children)
                    Traverse(kid, visitor, t, ref r);
            }
        }
        public static void DelegateMethod(KeyValuePair<string, string> data, NTree<KeyValuePair<string, string>> node, string t, ref NTree<KeyValuePair<string, string>> r)
        {
            string a = string.Empty;
            if (node.data.Key == t)
            {
                r = node;
                return;
            }
        }
