    public DataTable searchData(string query)
    {
        try
        {
            DataTable table = new DataTable();
            using(SqlConnection con = new SqlConnection(....constring here...))
            {
                using(SqlDataAdapter da = new SqlDataAdapter(query, con))
                   da.Fill(table);
            }
            return table;
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return null;
        }
    }
