    public static void AddNodeToTreeView(this TreeView tv, string Text, Cabinet cabinet)
    {
        TreeNode n = new TreeNode();
        n.Text = Text;
        n.Tag = cabinet;
        tv.Add(n);
    }
