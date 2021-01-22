            if (!Page.IsPostBack)
                PopulateRootLevel();
        }
        private void PopulateRootLevel()
        {
            SqlConnection objConn = new SqlConnection(connStr);
            SqlCommand objCommand = new SqlCommand(@"select FoodCategoryID,FoodCategoryName,(select count(*) FROM FoodCategories WHERE ParentID=c.FoodCategoryID) childnodecount FROM FoodCategories c where ParentID IS NULL", objConn);
            SqlDataAdapter da = new SqlDataAdapter(objCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PopulateNodes(dt, TreeView2.Nodes);
        }
        private void PopulateSubLevel(int parentid, TreeNode parentNode)
        {
            SqlConnection objConn = new SqlConnection(connStr);
            SqlCommand objCommand = new SqlCommand(@"select FoodCategoryID,FoodCategoryName,(select count(*) FROM FoodCategories WHERE ParentID=sc.FoodCategoryID) childnodecount FROM FoodCategories sc where ParentID=@parentID", objConn);
            objCommand.Parameters.Add("@parentID", SqlDbType.Int).Value = parentid;
            SqlDataAdapter da = new SqlDataAdapter(objCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PopulateNodes(dt, parentNode.ChildNodes);
        }
        protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
        }
        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["FoodCategoryName"].ToString();
                tn.Value = dr["FoodCategoryID"].ToString();
                nodes.Add(tn);
                //If node has child nodes, then enable on-demand populating
                tn.PopulateOnDemand = ((int)(dr["childnodecount"]) > 0);
            }
        }
