    int text;
    if(int.TryParse(this.Txtusers.Text, out text)
    {
        using(var con = new SqlConnection(connectionString)
        {
            using(var cmd  = new SqlCommand("select TOP (@top) * from Avaya_Id where LOB = @LOB and Status = 'Unassigned'", con))
            {
                cmd.Parameters.Add("@top", SqlDbType.Int).Value = text;
                cmd.Parameters.Add("@LOB", SqlDbType.Int).Value = DDLOB.SelectedItem.Value;
                con.Open();
                using(var rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }
    }
