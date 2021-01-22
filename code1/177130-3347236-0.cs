    using(IDataReader reader = connection.ExecuteReader())
    {
        do
        {
            while(reader.Read())
            {
                //Read record
            }
        } while(reader.NextResult());
    }
