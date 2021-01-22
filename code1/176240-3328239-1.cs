protected void Button1_Click(object sender, EventArgs e)
    {
        string con;
        con = "Data Source=CJ\\SQLEXPRESS;Initial Catalog=seq;Persist Security Info=True;User ID=sa;Password=123";
        using (SqlConnection cn = new SqlConnection(con))
        {
            cn.Open();
            using(SqlTransaction trans = cn.BeginTransaction())
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.Transaction = trans;
                cmd.CommandText = "INSERT INTO cust([cust_id],[cust_name],[cust_add]) VALUES(@cust_id,@cust_name,@cust_add)";
                cmd.Parameters.Add("@cust_id",CJ());
                cmd.Parameters.Add("@cust_name",TextBox1.Text);
                cmd.Parameters.Add("@cust_add",TextBox2.Text);
                cmd.ExecuteNonQuery();
                trans.Dispose();
            }
            cn.Close();
            Response.Write("<script>alert('DATA SAVED')</script>");
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
   }
