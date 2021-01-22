    if (context.Connection.State == System.Data.ConnectionState.Broken)
    {
        context.Connection.Close();
        context.Connection.Open();
    }
