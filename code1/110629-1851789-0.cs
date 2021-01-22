    public class TreeViewSample : Form
    {
        private TreeView _treeView;
        public TreeViewSample()
        {
            this._treeView = new System.Windows.Forms.TreeView();
            this._treeView.Location = new System.Drawing.Point(12, 12);
            this._treeView.Size = new System.Drawing.Size(200, 400);
            this._treeView.AfterExpand +=
                new TreeViewEventHandler(TreeView_AfterExpand);
            this.ClientSize = new System.Drawing.Size(224, 424);
            this.Controls.Add(this._treeView);
            this.Text = "TreeView Lazy Load Sample";
            InitializeTreeView();
        }
    
        void TreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == "dummy")
            {
                // this node has not yet been populated, launch a thread
                // to get the data
                ThreadPool.QueueUserWorkItem(state =>
                {
                    IEnumerable<SomeClass> childItems = GetData();
                    // load the data into the tree view (on the UI thread)
                    _treeView.BeginInvoke((Action)delegate
                    {
                        PopulateChildren(e.Node, childItems);
                    });
                });
            }
        }
    
        private void PopulateChildren(TreeNode parent, IEnumerable<SomeClass> childItems)
        {
            TreeNode child;
            TreeNode dummy;
            TreeNode originalDummyItem = parent.Nodes[0];
            foreach (var item in childItems)
            {
                child = new TreeNode(item.Text);
                dummy = new TreeNode("Loading. Please wait...");
                dummy.Tag = "dummy";
                child.Nodes.Add(dummy);
                parent.Nodes.Add(child);
            }
            originalDummyItem.Remove();
        }
    
        private IEnumerable<SomeClass> GetData()
        {
            // simulate that this takes some time
            Thread.Sleep(500);
            return new List<SomeClass>
            {
                new SomeClass{Text = "One"},
                new SomeClass{Text = "Two"},
                new SomeClass{Text = "Three"}
            };
        }
    
        private void InitializeTreeView()
        {
            TreeNode rootNode = new TreeNode("Root");
            TreeNode dummyNode = new TreeNode("Loading. Please wait...");
            dummyNode.Tag = "dummy";
            rootNode.Nodes.Add(dummyNode);
            _treeView.Nodes.Add(rootNode);
        }
    }
    
    public class SomeClass
    {
        public string Text { get; set; }
    }
