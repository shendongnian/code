using (var cn = new SqlConnection(ConnectionString))
{
    cn.Open();
    using (var command = cn.CreateCommand())
    {
        // Use command..
    }
}
Behind the scenes this is what the `using` statement translates into, you can appreciate how it helps to reduce boilerplate:
{
    var cn = new SqlConnection(ConnectionString);
    try
    {
        cn.Open();
        {
            var command = cn.CreateCommand();
            try
            {
                // Use command..
            }
            finally
            {
                command.Dispose();
            }
        }
    }
    finally
    {
        cn.Dispose();
    }
}
By disposing the `SqlConnection` instance with the `using` statement you can be sure that the connection will be closed after leaving the scope, even if an exception occurs.
