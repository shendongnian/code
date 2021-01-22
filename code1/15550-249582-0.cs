    using (var connection = new SqlConnection("..."))
    using (var command = new SqlCommand("MySprocName", connection))
    {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Param1", param1Value);
        return command.ExecuteReader();
    }
