    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagerConnectionString"].ConnectionString);
        private void btnLoadNodes_Click(object sender, EventArgs e)
        {
            con.Open();
            treeViewCat.Nodes.Clear();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblProductCategories WHERE Cat_ParentCat =0", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                TreeNode node = new TreeNode();
                node.Text = sdr["Cat_Name"].ToString() + sdr["Cat_ID"].ToString();
                treeViewCat.Nodes.Add(node);
                SqlCommand cmdChild = new SqlCommand("SELECT * FROM tblProductCategories WHERE Cat_ParentCat =" + sdr["Cat_ID"].ToString(), con);
                SqlDataReader childSDR = cmdChild.ExecuteReader();
                while (childSDR.Read())
                {
                    node.Nodes.Add(childSDR["Cat_Name"].ToString() + childSDR["Cat_ID"].ToString());
                    
                }
            }
            con.Close();
        }
