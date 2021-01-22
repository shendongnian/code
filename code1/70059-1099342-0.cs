    protected void DetailsView1_ItemInserted(object sender, EventArgs e)
    {
        using (SqlCommand cmd2 = new SqlCommand("uspUpdateDisplayHours", cn))
        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd2))        
            {
                var dataSet = new DataSet();
                cn.Open();
                cmd2.CommandType = CommandType.StoredProcedure;
                adapter.Fill(dataSet);
                var _result = //get to your result some how.
                DetailsView.DataSource = result;
                cn.Close();
            }
            DetailsView1.DataBind();
        }
    }
