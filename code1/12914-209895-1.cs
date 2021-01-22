    using(SqlCommand command = ...)
    {
        command.Connection = ...;
        command.Transaction = ...; // if in a transaction
        SqlParameter parameter = command.Parameters.Add("@Items", ...);
        foreach(string itemList in ConcatenateValues(values, "~", 8000, false))
        {
            parameter.Value = itemList;
            command.ExecuteNonQuery();
        }
    }
