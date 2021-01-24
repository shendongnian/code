    private void frmSampleApp_Load(object sender, EventArgs e)
    {
        var dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("ParentId", typeof(int));
        dt.Rows.Add(1, "Menu 1", DBNull.Value);
        dt.Rows.Add(11, "Menu 1-1", 1);
        dt.Rows.Add(111, "Menu 1-1-1", 11);
        dt.Rows.Add(112, "Menu 1-1-2", 11);
        dt.Rows.Add(12, "Menu 1-2", 1);
        dt.Rows.Add(121, "Menu 1-2-1", 12);
        dt.Rows.Add(122, "Menu 1-2-2", 12);
        dt.Rows.Add(123, "Menu 1-2-3", 12);
        dt.Rows.Add(124, "Menu 1-2-4", 12);
        dt.Rows.Add(2, "Menu 2", DBNull.Value);
        dt.Rows.Add(21, "Menu 2-1", 2);
        dt.Rows.Add(211, "Menu 2-1-1", 21);
        var source = dt.AsEnumerable();
        var list = GetNavBarItems(
                source,
                (r) => r.Field<int?>("ParentId") == null,
                (r, s) => s.Where(x => x.Field<int?>("ParentId") == r.Field<int?>("Id")),
                (r) => new NavBarItem()
                {
                    ID = r.Field<int>("Id"),
                    Text = r.Field<string>("Name"),
                    ParentID = r.Field<int?>("ParentId")
                }).ToList();
        foreach (var item in list)
        {
            TreeNode parentNode = null;
            parentNode = treeView1.Nodes.Add(item.Text.ToString());
            BindData(Convert.ToInt32(item.ParentID), parentNode);
        }
    }
    public void BindData(int parentId, TreeNode parentNode)
    {
        var dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("ParentId", typeof(int));
        dt.Rows.Add(1, "Menu 1", DBNull.Value);
        dt.Rows.Add(11, "Menu 1-1", 1);
        dt.Rows.Add(111, "Menu 1-1-1", 11);
        dt.Rows.Add(112, "Menu 1-1-2", 11);
        dt.Rows.Add(12, "Menu 1-2", 1);
        dt.Rows.Add(121, "Menu 1-2-1", 12);
        dt.Rows.Add(122, "Menu 1-2-2", 12);
        dt.Rows.Add(123, "Menu 1-2-3", 12);
        dt.Rows.Add(124, "Menu 1-2-4", 12);
        dt.Rows.Add(2, "Menu 2", DBNull.Value);
        dt.Rows.Add(21, "Menu 2-1", 2);
        dt.Rows.Add(211, "Menu 2-1-1", 21);
        var source = dt.AsEnumerable();
        var list = GetNavBarItems(
                source,
                (r) => r.Field<int?>("ParentId") == null,
                (r, s) => s.Where(x => x.Field<int?>("ParentId") == r.Field<int?>("Id")),
                (r) => new NavBarItem()
                {
                    ID = r.Field<int>("Id"),
                    Text = r.Field<string>("Name"),
                    ParentID = r.Field<int?>("ParentId")
                }).ToList();
            TreeNode childNode; 
        foreach (var item in list)
        {
            if (parentNode == null)
                childNode = treeView1.Nodes.Add(item.Text.ToString());
            else
                childNode = parentNode.Nodes.Add(item.Text.ToString());
            BindData(Convert.ToInt32(item.ID.ToString()), childNode); //An unhandled exception of type 'System.StackOverflowException' occurred in System.Windows.Forms.dll
        }
    }
    
    private IEnumerable<NavBarItem> GetNavBarItems<T>(
    IEnumerable<T> source,
    Func<T, Boolean> isRoot,
    Func<T, IEnumerable<T>, IEnumerable<T>> getChilds,
    Func<T, NavBarItem> getItem)
        {
            IEnumerable<T> roots = source.Where(x => isRoot(x));
            foreach (T root in roots)
                yield return ConvertEntityToNavBarItem(root, source, getChilds, getItem); ;
        }
        private NavBarItem ConvertEntityToNavBarItem<T>(
        T entity,
        IEnumerable<T> source,
        Func<T, IEnumerable<T>, IEnumerable<T>> getChilds,
        Func<T, NavBarItem> getItem)
        {
            NavBarItem node = getItem(entity);
            var childs = getChilds(entity, source);
            foreach (T child in childs)
                node.Childs.Add(ConvertEntityToNavBarItem(child, source, getChilds, getItem));
            return node;
        }
    }
    public class NavBarItem
    {
        public NavBarItem()
        {
            Childs = new List<NavBarItem>();
        }
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Text { get; set; }
        public List<NavBarItem> Childs { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
