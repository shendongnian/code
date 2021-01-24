    using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM EmployeeIDs", c))
    {
    }
    using( ..command2.. )
    {
     SqlDataReader dr = command2.ExecuteReader();
    }
