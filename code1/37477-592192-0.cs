    using (IDataReader dr = db.ExecuteReader(command))
    {
        /* ... your code ... */
        if (dr is SqlDataReader)
        {
            TimeSpan myTimeSpan = ((SqlDataReader)dr).GetTimeSpan(columnIndex)
        }
        else
        {
            throw new Exception("The DataReader is not a SqlDataReader")
        }
        /* ... your code ... */
    }
