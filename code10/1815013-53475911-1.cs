     SqlConnection sqlcon = new SqlConnection(SQL);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand("insert into  userbranchtbl (uId,branchId) VALUES(@uId,@branchId)", sqlcon);
        {
            foreach (ListItem item in this.branches.Items)
            {
                if (item.Selected)
                {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@branchId", item.Value);
                cmd.Parameters.AddWithValue("@uId", uId);
                cmd.ExecuteNonQuery();
                }
            }
        }
