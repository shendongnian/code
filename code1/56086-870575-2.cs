        string myString = "3,6,12";
        SqlConnection conn = GetSqlConnection();
        GridView gvw = GetGridView();
        SqlCommand cmd = new SqlCommand("GetProductsByDelimitedString", conn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;        
        cmd.Parameters.AddWithValue("@myString", myString);
        try
        {
            conn.Open();
            gvw.DataSource = cmd.ExecuteReader();
            gvw.DataBind();
            conn.Close();
        }
        catch
        {
            // something bad happened
        }
