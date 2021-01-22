    public bool Equals(TreeNode x, TreeNode y)
    {
        return x.Text == y.Text;
    }
    public int GetHashCode(TreeNode obj)
    {
        return obj.Text.GetHashCode();
    }
