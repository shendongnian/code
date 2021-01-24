    SqlConnection sqlconn = new SqlConnection(SQL);
            sqlconn.Open();
            SqlCommand scmd = new SqlCommand("insert into usertbl (userid,pass)values(@userid,@pass); SELECT SCOPE_IDENTITY()", sqlconn);
            scmd.Parameters.AddWithValue("@userid", userid.Text);
            scmd.Parameters.AddWithValue("@pass", password.Text);
            int uid = Convert.ToInt32(scmd.ExecuteScalar());
    
            //batch loop of multiple items selected from listbox
            string listBoxValues = string.Empty;
            string listBoxText = string.Empty;
            foreach (ListItem item in this.branches.Items)
            {
                if (item.Selected)
                {
                    listBoxText = listBoxText + item.Text;
                    listBoxValues = listBoxValues + item.Value;
       
                }
            }
    
            SqlConnection sqlcon = new SqlConnection(SQL);
            SqlCommand cmd = new SqlCommand("insert into branchtbl (branchname,loc_code) VALUES(@branchname,@loc_code); SELECT SCOPE_IDENTITY()", sqlcon);
            sqlcon.Open();
            cmd.Parameters.AddWithValue("@branchname", listBoxText);
            cmd.Parameters.AddWithValue("@loc_code", listBoxValues);
            int branchid = Convert.ToInt32(cmd.ExecuteScalar());
    
            SqlCommand scmd2 = new SqlCommand("insert into  userbranchtbl (uid,branchid) VALUES(@uid,@branchid)", sqlcon);
            scmd2.Parameters.AddWithValue("@uid", uid);
            scmd2.Parameters.AddWithValue("@branchid", uid);
            scmd2.ExecuteNonQuery();
            sqlcon.Close();
