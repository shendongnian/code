    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<MyObject> list = new List<MyObject>();
            list.Add(new MyObject(){Id=1, Name="Alice", ParentId=0});
            list.Add(new MyObject(){Id=2, Name="Bob", ParentId=1});
            list.Add(new MyObject(){Id=3, Name="Charlie", ParentId=1});
            list.Add(new MyObject(){Id=4, Name="David", ParentId=2});            
            BindTree(list, null);            
        }
    }
    private void BindTree(IEnumerable<MyObject> list, TreeNode parentNode)
    {
        var nodes = list.Where(x => parentNode == null ? x.ParentId == 0 : x.ParentId == int.Parse(parentNode.Value));
        foreach (var node in nodes)
        {
            TreeNode newNode = new TreeNode(node.Name, node.Id.ToString());
            if (parentNode == null)
            {
                treeView1.Nodes.Add(newNode);
            }
            else
            {
                parentNode.ChildNodes.Add(newNode);
            }
            BindTree(list, newNode);
        }
    }
