     //dtTree  should be accessible in both page load and AddNodes()
        //DocsMenu is the treeview Id
              DataTable dtTree = new DataTable(); 
    //declare your connection string
                    protected void Page_Load(object sender, EventArgs e)
                    {
                        //DataTable dtTree = new DataTable();
                        using (con)
                        {
                            con.Open();
                            
                            string sQuery = "Select topicId,parentid,name from tbl_topicMaster";
                            SqlCommand cmd = new SqlCommand(sQuery, con);
                            cmd.CommandType = CommandType.Text;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dtTree);
                            da.Dispose();
                            con.Close();
                        }
                        
                        AddNodes(-1, DocsMenu.Nodes);
                    }
            
            
            
            
                    void AddNodes(int id, TreeNodeCollection tn)
                    {
                        foreach (DataRow dr in dtTree.Select("parentid= " + id))
                        {
                            TreeNode sub = new TreeNode(dr["name"].ToString(), dr["topicId"].ToString());
                            tn.Add(sub);
                            AddNodes(Convert.ToInt32(sub.Value), sub.ChildNodes);
                        }
                    }
