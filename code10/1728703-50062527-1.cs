    . . .
    using(SqlConnection connection = new SqlConnection("yourConnectionString"))
    {
        SqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = @"INSERT INTO [CustomerInfo] (CustomerName, CustomerEmail, CustomerAddress)
                            VALUES (@Name, @Email, @Address)";
        cmd.Parameters.AddRange(new SqlParameter[]
        {
            new SqlParameter("@Name", name),
            new SqlParameter("@Email", email),
            new SqlParameter("@Address", address)
        });
        connection.Open();
        cmd.ExecuteNonQuery();
    }
    . . .
