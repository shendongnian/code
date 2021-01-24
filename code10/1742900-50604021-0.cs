    private DataSet GetData(string query)
    {
    string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    SqlCommand cmd = new SqlCommand(query);
    using (SqlConnection con = new SqlConnection(conString))
    {
        using (SqlDataAdapter sda = new SqlDataAdapter())
        {
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            using (DataSet ds = new DataSet())
            {
                sda.Fill(ds);
                return ds;
            }
        }
    }
    }
