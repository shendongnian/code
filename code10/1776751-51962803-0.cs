     myConn.Open();
    SqlCommand cmd = new SqlCommand(@"select User_id , LoginDate from LoginLog where LoginDate between
                                     ('" + TextBox1.Text + "') and ('" + TextBox2.Text + "')", myConn);
    DataTable dt = new DataTable();
    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    sda.Fill(dt);
    GridView1.DataSource = dt;
    if (dt.Rows.Count > 0)
    {
        GridView1.DataBind();
    }
    else
    {
        Lab4.Text = "No Records Found ";
    }
    myConn.Close();
