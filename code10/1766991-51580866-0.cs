        class BSTree
        {
            public Node Root;
            private int MaxNiv;
            private List<Node> nodes = new List<Node>();
            public BSTree()
            {
                this.Root = null;
                this.MaxNiv = -1;
            }
            public void Insert(int x)
            {
                Node tmp = new Node(x);
                nodes.Add(tmp);
                if (this.Root == null)
                {
                    tmp.Niveli = 0;
                    this.Root = tmp;
                }
                else InsertNode(tmp);
                if (tmp.Niveli > this.MaxNiv) MaxNiv = tmp.Niveli;
            }
            public void ConnectLeafs()
            {
                //TODO
            }
            public List<Node> ReturnNodesAroundTheTree()
            {
                return nodes.Where(x => IsLeaf(x)).ToList();
            }
        }
