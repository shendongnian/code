    public DataTable GetData(int? id, string name, int? price)
    {
        DataTable dt = new DataTable();
        var commandText = "SELECT * FROM Products WHERE " +
            "(Id = @Id OR @Id is NULL) AND " +
            "(Name LIKE '%' + @Name + '%' OR @Name IS NULL) AND " +
            "(Price = @Price OR @Price IS NULL)";
        var connectionString = @"Data Source=.;Initial Catalog=SampleDb;Integrated Security=True";
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(commandText, connection))
        {
            command.Parameters.Add("@Id", SqlDbType.Int).Value = 
                (object)id ?? DBNull.Value;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = 
                (object)name ?? DBNull.Value;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = 
                (object)price ?? DBNull.Value;
            using (var datAdapter = new SqlDataAdapter(command))
                datAdapter.Fill(dt);
        }
        return dt;
    }
