    using(SqlConnection sqlCon = new SqlConnection(Program.cs))
    {
        sqlCon.Open();
        using(SqlDataAdapter da = new SqlDataAdapter("dbo.login", sqlCon))
        { 
            DataTable dtbl = new DataTable();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@user", user.Text);
            da.SelectCommand.Parameters.AddWithValue("@pass", pass.Text);
            da.Fill(dtbl);
            if (dtbl.Rows[0][0].ToString() == "1")
            {
                //here rewrite code with using statement
                DataTable dtbl2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter("dbo.loginType", sqlCon);
                da2.SelectCommand.CommandType = CommandType.StoredProcedure;
                da2.SelectCommand.Parameters.AddWithValue("@user", user.Text.Trim());
                da2.Fill(dtbl2);
    
                t = dtbl2.Rows[0][0].ToString();
                System.Diagnostics.Debug.WriteLine("t is : "+t);
                if (t.Equals("A"))
                {
                    System.Diagnostics.Debug.WriteLine("innnnnnnn");
                    this.Hide();
                    AdminMainForm form = new AdminMainForm();
                    form.Show();
                }
            }
        }
    }
