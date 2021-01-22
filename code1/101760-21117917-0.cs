    public partial class winTree : TreeView
    {
        private NodesCollection allNodes = new NodesCollection();
        [ReadOnly(true)]
        public new NodesCollection Nodes { get { return allNodes; } }
        private string filtro = string.Empty;
        public String Filtro
        {
            get { return filtro; }
            set { filtro = value; filtrarNodos(); }
        }
        public winTree()
        {
            InitializeComponent();
            allNodes.NodeAdd += OnNodeAdd;
            allNodes.NodeRemove += OnNodeRemove;
            allNodes.NodesClear += OnNodesClear;
        }
        private void OnNodeAdd(object sender, EventArgs e)
        {
            TreeNode n = (TreeNode)sender;
            if (passFilter(n))
            {
                base.Nodes.Add(n);
            }
        }
        private void OnNodeRemove(object sender, EventArgs e)
        {
            base.Nodes.Remove((TreeNode)sender);
        }
        private void OnNodesClear(object sender, EventArgs e)
        {
            base.Nodes.Clear();
        }
        private void filtrarNodos()
        {
            this.BeginUpdate();
            base.Nodes.Clear();
            foreach(TreeNode n in this.Nodes)
            {
                if (passFilter(n))
                {
                    base.Nodes.Add(n);
                }
            }
            this.EndUpdate();
        }
        private bool passFilter(TreeNode nodo)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                return true;
            }
            else
            {
                return nodo.Text.ToLower().Contains(filtro.ToLower());
            }
        }
    }
    public class NodesCollection : IList<TreeNode>
    {
        private List<TreeNode> nodos = new List<TreeNode>();
        public event EventHandler NodeAdd;
        public event EventHandler NodeRemove;
        public event EventHandler NodesClear;
        private void OnNodeAdd(TreeNode nodo)
        {
            if (NodeAdd != null)
            {
                NodeAdd(nodo, EventArgs.Empty);
            }
        }
        private void OnNodeRemove(TreeNode nodo)
        {
            if (NodeRemove != null)
            {
                NodeRemove(nodo, EventArgs.Empty);
            }
        }
        private void OnNodesClear()
        {
            if (NodeRemove != null)
            {
                NodesClear(this, EventArgs.Empty);
            }
        }
        
        #region IList<TreeNode>
            public int IndexOf(TreeNode item)
            {
                return nodos.IndexOf(item);
                OnNodeAdd(item);
            }
            public void Insert(int index, TreeNode item)
            {
                nodos.Insert(index, item);
                OnNodeAdd(item);
            }
            public void RemoveAt(int index)
            {
                TreeNode nodo = nodos[index];
                nodos.RemoveAt(index);
                OnNodeRemove(nodo);
            }
            public TreeNode this[int index]
            {
                get
                {
                    return nodos[index];
                }
                set
                {
                    OnNodeRemove(nodos[index]);
                    nodos[index] = value;
                    OnNodeAdd(nodos[index]);
                }
            }
            public void Add(TreeNode item)
            {
                nodos.Add(item);
                OnNodeAdd(item);
            }
            public void Clear()
            {
                nodos.Clear();
                OnNodesClear();
            }
            public bool Contains(TreeNode item)
            {
                return nodos.Contains(item);
            }
            public void CopyTo(TreeNode[] array, int arrayIndex)
            {
                nodos.CopyTo(array, arrayIndex);
            }
            public int Count
            {
                get { return nodos.Count(); }
            }
            public bool IsReadOnly
            {
                get { return true; }
            }
            public bool Remove(TreeNode item)
            {
                bool res = nodos.Remove(item);
                if (res)
                {
                    OnNodeRemove(item);
                }
                return res;
            }
            public IEnumerator<TreeNode> GetEnumerator()
            {
                return nodos.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return nodos.GetEnumerator();
            }
        #endregion
    }
