    public void func_make_sql_filters_string(TreeViewEventArgs e1 , TreeViewCancelEventArgs e2)
    {
        TreeNode node = e1?.Node ?? e2?.Node;
        if (node == null)
        {
            throw new Exception("Both events are null or don't have a related node.");
        }
        if (node.Level == 1)
        {
            array_treeView_checking[node.Index] = $"{node.Parent} = N'{node.Text}'";
        }
    }
