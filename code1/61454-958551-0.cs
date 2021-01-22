    using(var sqlConnectionA = new ...)
    using(var sqlConnectionB = new ...)
    {
        try
        {
            // Perform queries here.
        }
        catch (SqlException exSql)
        {
            // SQL error
        }
    }
