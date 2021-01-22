    var parameters = new string[items.Length];
    var cmd = new SqlCommand();
    for (int i = 0; i < items.Length; i++)
    {
        parameters[i] = string.Format("@Age{0}", i);
        cmd.Parameters.AddWithValue(parameters[i], items[i]);
    }
    cmd.CommandText = string.Format("SELECT * from TableA WHERE Age IN ({0})", string.Join(", ", parameters));
    cmd.Connection = new SqlConnection(connStr);
