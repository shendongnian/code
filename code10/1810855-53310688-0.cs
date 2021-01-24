    using System.Windows.Forms;
    public static class TreeViewExtensiona
    {
        public static TreeNode FindByPath(this TreeNodeCollection nodes, string path)
        {
            TreeNode found = null;
            foreach (TreeNode n in nodes)
            {
                if (n.FullPath == path)
                    found = n;
                else
                    found = FindByPath(n.Nodes, path);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
