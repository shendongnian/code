    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TreeNode tNode1 = new TreeNode();
            tNode1.Text = "HeadNode1";
            tNode1.Value = "HeadNode1";
            TreeNode h1ChildNode1 = new TreeNode();
            h1ChildNode1.Text = "Head1Child1";
            tNode1.ChildNodes.Add(h1ChildNode1);
            TreeNode h1GrandChild1 = new TreeNode();
            h1GrandChild1.Text = "Head1Child1Grand1";
            h1ChildNode1.ChildNodes.Add(h1GrandChild1);
            TreeNode h1ChildNode2 = new TreeNode();
            h1ChildNode2.Text = "Head1Child2";
            tNode1.ChildNodes.Add(h1ChildNode2);
            TreeNode h1ChildNode3 = new TreeNode();
            h1ChildNode3.Text = "Head1Child3";
            tNode1.ChildNodes.Add(h1ChildNode3);
            TreeView1.Nodes.Add(tNode1);
            TreeNode tNode2 = new TreeNode();
            tNode2.Text = "HeadNode2";
            tNode2.Value = "HeadNode2";
            TreeView1.Nodes.Add(tNode2);
            ServerSideChangeSelection(TreeView1, true);
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (TreeNode node in TreeView1.Nodes)
            {
                nodes.Add(node);
                if (node.ChildNodes.Count > 0)
                {
                    foreach (TreeNode childNode in node.ChildNodes)
                    {
                        nodes.Add(childNode);
                    }
                }
            }
            Nodes = nodes;
        }
    }
