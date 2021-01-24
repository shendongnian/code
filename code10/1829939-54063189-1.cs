    public partial class TreeTest : Form
    {
        public TreeTest()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagerConnectionString"].ConnectionString);
            
            
            var dt = new DataTable();
            var source = dt.AsEnumerable();
            var nodes = GetTreeNodes(
                /*The data table*/
                source,
                /*How detect if a row is a root row*/
                (r) => r.Field<int>("Cat_ParentCat") == 0,
                /*How to find child rows for a row*/
                (r, s) => s.Where(x => r["Cat_ID"].Equals(x["Cat_ParentCat"])),
                /*How to create a node from a row*/
                (r) => new TreeNode { 
                Text = r.Field<string>("Cat_Name"),
               Tag = r.Field<int>("Cat_ID")
        }
        );
                treeViewCat.Nodes.AddRange(nodes.ToArray());
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagerConnectionString"].ConnectionString);
        private void btnLoadNodes_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tblProductCategories WHERE Cat_ParentCat =0";
            GetData(query);
        }
        public DataTable GetData( string command)
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter(command, con))
                da.Fill(dt);
            return dt;
        }
            private IEnumerable<TreeNode> GetTreeNodes<T>(
                IEnumerable<T> source,
                Func<T, Boolean> isRoot,
                Func<T, IEnumerable<T>, IEnumerable<T>> getChilds,
                Func<T, TreeNode> getItem)
            {
                IEnumerable<T> roots = source.Where(x => isRoot(x));
                foreach (T root in roots)
                    yield return ConvertEntityToTreeNode(root, source, getChilds, getItem); ;
            }
        private TreeNode ConvertEntityToTreeNode<T>(
            T entity,
            IEnumerable<T> source,
            Func<T, IEnumerable<T>, IEnumerable<T>> getChilds,
            Func<T, TreeNode> getItem)
        {
            TreeNode node = getItem(entity);
            var childs = getChilds(entity, source);
            foreach (T child in childs)
                node.Nodes.Add(ConvertEntityToTreeNode(child, source, getChilds, getItem));
            return node;
        }
        private void btnGetNode_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(treeViewCat.SelectedNode.Tag.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
