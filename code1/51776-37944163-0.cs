        private void PopulateNodes(this TreeView treeView1, DataTable dataTable, string name, string id, string parentId)
        {
            treeView1.BeginUpdate();
            foreach (DataRow row in dataTable.Rows)
            {
                treeView1.Nodes.Add(new IdNode() { Name = row[name].ToString(), Text = row[name].ToString(), Id = row[id], ParentId = row[parentId], Tag = row });
            }
            foreach (IdNode idnode in treeView1.Nodes.OfType<IdNode>())
            {
                foreach (IdNode newparent in treeView1.Nodes.OfType<IdNode>())
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
        internal class IdNode : TreeNode
        {
            public object Id { get; set; }
            public object ParentId { get; set; }
        }
