    public DataTable LoadEmployees(string category)
    {
        var query = 
          "SELECT employee_id, employee_name FROM employees WHERE employee_category=@category";
        var parameter = new SqlParameter 
        {
            ParameterName = "@category",
            SqlDbType = SqlDbType.Varchar,
            Value = category
        };
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(query, connection))
        using (var adapter = new SqlDataAdapter())
        {
            command.Parameters.Add(parameter);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
