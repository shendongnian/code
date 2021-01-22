    try
    {
        using (SqlConnection conn = new SqlConnection(...))
        {
            // do your db work here
            // whatever happens the connection will be safely disposed
        }
    }
    catch (Exception ex)
    {
        // do your stuff here (eg, logging)
        // nb: the connection will already have been disposed at this point
    }
    finally
    {
        // if you need it
    }
