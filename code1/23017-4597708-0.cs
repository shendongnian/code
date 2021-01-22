    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = RunQuery("Select topicid,name from Topics where Parent_ID IS NULL");
           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
           { 
               TreeNode root = new TreeNode(ds.Tables[0].Rows[i][1].ToString(),ds.Tables[0].Rows[i][0].ToString());
               root.SelectAction = TreeNodeSelectAction.Expand;
               CreateNode(root);
               TreeView1.Nodes.Add(root);
           }
        
           
        
    }
    void CreateNode(TreeNode node)
    {
        DataSet ds = RunQuery("Select topicid, name from Category where Parent_ID =" + node.Value);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return;
        }
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            TreeNode tnode = new TreeNode(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString());
            tnode.SelectAction = TreeNodeSelectAction.Expand;
            node.ChildNodes.Add(tnode);
            CreateNode(tnode);
        }
    }
    DataSet RunQuery(String Query)
    {
        DataSet ds = new DataSet();
        String connStr = "???";//write your connection string here;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand objCommand = new SqlCommand(Query, conn);
            SqlDataAdapter da = new SqlDataAdapter(objCommand);
            da.Fill(ds);
            da.Dispose();
        }
        return ds;
    }
