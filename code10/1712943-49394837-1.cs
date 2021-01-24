    private const string cnString = "Server=localhost;Database=exam;Integrated Security=True";
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "select F1,F2,F3,F4 from [dbo].[CandDbase] Where F4 = @search";
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(cnString))
        using (SqlCommand xp = new SqlCommand(sql, con))
        using (SqlDataAdapter da = new SqlDataAdapter(xp))
        {
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = TextBox1.Text;
            da.Fill(ds, "Name");
        }
        GridView1.DataSource = ds.Tables["Name"];
        GridView1.DataBind();
    }
