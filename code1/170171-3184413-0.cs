    private void FillTreeView(object sender, EventArgs e)
    {
        // create fake datatable
        DataTable dt = new DataTable();
        dt.Columns.Add("UserId",typeof(int));
        dt.Columns.Add("Name",typeof(string));
        dt.Columns.Add("ParentId", typeof(int));
    
    
        dt.Rows.Add(new object[] { 3, "Level_1_A", 2 });
        dt.Rows.Add(new object[] { 4, "Level_1_B", 2 });
        dt.Rows.Add(new object[] { 2, "Level_0_A", 0 });
        dt.Rows.Add(new object[] { 5, "Level_2_A", 3 });
        dt.Rows.Add(new object[] { 6, "Level_2_B", 3 });
        dt.Rows.Add(new object[] { 7, "Level_0_B", 0 });
        dt.Rows.Add(new object[] { 8, "Level_1_C", 7 });
    
        // call recursive function
        AddCurrentChild(0, dt, treeView1.Nodes);
    }
    
    private static void AddCurrentChild(int parentId, DataTable dt, TreeNodeCollection nodes)
    {
        var rows = dt.Select("ParentId = " + parentId);
        foreach (var row in rows)
        {
            var userId = (int) row["UserId"];
            var name = row["Name"] as string;
    
            var node = nodes.Add(userId.ToString(), name.ToString());
            node.Tag = row; // if you need to keep a row reference on the node
            AddCurrentChild(userId, dt, node.Nodes);
        }
    }
