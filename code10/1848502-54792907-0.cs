using (var cn = new SqlConnection(ConnectionString))
{
    cn.Open();
    using (var command = cn.CreateCommand())
    {
        // Use command..
    }
}
By disposing the `SqlConnection` instance with the `using` statement you can be sure that the connection will be closed after leaving the scope, even if an exception occurs.
