    protected void DetailsView1_ItemInserted(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        using (SqlCommand cmd2 = new SqlCommand("uspUpdateDisplayHours", cn))
        {
            cmd2.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(cmd2).Fill(ds);
        }
        DetailsView1.DataSource = ds;
        DetailsView1.DataBind();
        }
    }
