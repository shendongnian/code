    DataTable dtTree = new DataTable();
    public void CollTree()
        {
            using (SqlConnection conn = new SqlConnection((ConfigurationManager.ConnectionStrings["sconn"].ConnectionString)))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AssetRegisterTreeGet";
                cmd.Parameters.Add("@AssetID", SqlDbType.Int).Value = Request.QueryString["Id"].ToString();
                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTree);
                da.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
            AddNodes(-2147483648, TreeView1.Nodes);
        }
        void AddNodes(int id, TreeNodeCollection tn)
        {
            foreach (DataRow dr in dtTree.Select("ParentAssetID = " + id))
            {
                TreeNode sub = new TreeNode(dr["AssetNumber"].ToString(), dr["AssetID"].ToString());
                tn.Add(sub);
                AddNodes(Convert.ToInt32(sub.Value), sub.ChildNodes);
            }
        }
