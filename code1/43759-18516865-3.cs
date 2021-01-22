    public static Dictionary<string, string> ExecuteCaseInsensitiveDictionary(string query, string connectionString, Dictionary<string, string> queryParams = null)
    {
        Dictionary<string, string> CaseInsensitiveDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    // Add the parameters for the SelectCommand.
                    if (queryParams != null)
                        foreach (var param in queryParams)
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (DataColumn column in dt.Columns)
                            {
                                CaseInsensitiveDictionary.Add(column.ColumnName, row[column].ToString());
                            }
                        }
                    }
                }
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return CaseInsensitiveDictionary;
    }
