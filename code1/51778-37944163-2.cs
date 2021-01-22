        internal class IdNode : TreeNode
        {
            public object Id { get; set; }
            public object ParentId { get; set; }
        }
        public static void PopulateNodes(this TreeView treeView1, DataTable dataTable, string name, string id, string parentId)
        {
            treeView1.BeginUpdate();
            foreach (DataRow row in dataTable.Rows)
            {
                treeView1.Nodes.Add(new IdNode() { Name = row[name].ToString(), Text = row[name].ToString(), Id = row[id], ParentId = row[parentId], Tag = row });
            }
            foreach (IdNode idnode in GetAllNodes(treeView1).OfType<IdNode>())
            {
                foreach (IdNode newparent in GetAllNodes(treeView1).OfType<IdNode>())
                {
                    if (newparent.Id.Equals(idnode.ParentId))
                    {
                        treeView1.Nodes.Remove(idnode);
                        newparent.Nodes.Add(idnode);
                        break;
                    }
                }
            }
            treeView1.EndUpdate();
        }
        public static List<TreeNode> GetAllNodes(this TreeView tv)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode child in tv.Nodes)
            {
                result.AddRange(GetAllNodes(child));
            }
            return result;
        }
        public static List<TreeNode> GetAllNodes(this TreeNode tn)
        {
            List<TreeNode> result = new List<TreeNode>();
            result.Add(tn);
            foreach (TreeNode child in tn.Nodes)
            {
                result.AddRange(GetAllNodes(child));
            }
            return result;
        }
