    using (ConnectionManager cm = ConnectionManager.Create())
    {
        // Get the SqlConnection for use.
        // No need for a using statement, when Dispose is
        // called on the connection manager, the connection will be
        // closed.
        SqlConnection connection = cm.Connection;
    
        // Use connection appropriately.
    }
