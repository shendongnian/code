    var dt = new DataTable();
    using (SqlConnection conn3 = new SqlConnection(connectionString3))
    {
        SqlCommand cmd3 = new SqlCommand("SELECT DISTINCT GLAccountEOC, EOCDescription FROM Acct_GLAccount WHERE CostCenter = @CostCenter Order By EOCDescription", conn3);
        cmd3.Parameters.Add("@CostCenter", System.Data.SqlDbType.Int);
        cmd3.Parameters["@CostCenter"].Value = "3215";
        try
        {
            conn3.Open();
            SqlDataReader cmdreader3 = cmd3.ExecuteReader();
            if (cmdreader3.HasRows)
            {
                dt.Load(cmdreader3);
                ddl.DataSource = dt; // use DataTable instead of SqlDataReader
                ddl.DataValueField = "GLAccountEOC";
                ddl.DataTextField = "EOCDescription";
                ddl.DataBind();
            }
            cmdreader3.Close();
        }
        finally
        {
            conn3.Close();
        }
    }
