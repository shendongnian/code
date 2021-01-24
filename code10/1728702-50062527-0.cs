    . . .
    using(SqlConnection connection = new SqlConnection("yourConnectionString"))
    {
        SqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = @"INSERT INTO [CustomerInfo] (CustomerName, CustomerEmail, CustomerAddress)
                            VALUES (@Name, @Email, @Address)";
        cmd.Parameters.Add(new SqlParameter("@Name", name));
        cmd.Parameters.Add(new SqlParameter("@Email", email));
        cmd.Parameters.Add(new SqlParameter("@Address", address));
        connection.Open();
        cmd.ExecuteNonQuery();
    }
    . . .
