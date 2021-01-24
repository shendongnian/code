    public static void Main(string [] args)
    {
        PopulateComboBox(); // Will kick off everything.
    }
    public static void PopulateComboBox()
    {
        DataTable table = ExecuteDataTable("SELECT Username FROM Users WHERE firstname = @firstname", new SqlParameter("Bob", SqlDbType.VarChar);
        
        foreach(DataRow row in table.Rows)
        {
            comboBox1.Items.Add(row["Username"].ToString());
        }
    }
    public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                return dataset.Tables[0];
            }
        }
    }
