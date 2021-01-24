    using (SqlDataAdapter sda = new SqlDataAdapter(com))
    {
         DataTable dt = new DataTable();
         sda.Fill(dt);
         smry.DataSource = dt;
         smry.DataBind();
    }
