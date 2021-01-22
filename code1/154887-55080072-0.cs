    using System.Windows.Forms;
    using System.Xml.Linq;
    namespace _Solution.Class
    {
        class Load
        {
            public void tree_pop(TreeView treeview)
            {
                treeview.Nodes.Clear();
                XElement doc = XElement.Load("xml_file.xml");
                TreeNode root = new TreeNode("root");
                treeview.Nodes.Add(root);
                add_nodes(root, doc);
                treeview.ExpandAll();
            }
            private void add_nodes(TreeNode t_node, XElement x_node)
            {
                foreach (XElement node in x_node.Elements())
                {
                    TreeNode n_node = t_node.Nodes.Add(node.Attribute("name").Value);
                    add_nodes(n_node, node);
                    if (n_node.Nodes.Count == 0) n_node.EnsureVisible();
                }
            }
        }
    }
