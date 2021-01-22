    using(var reader = SqlHelper.ExecuteReader(etc. etc. etc.))
    {
        while(reader.read()){
        {
            //Only need to do this if you don't want your string to be null
            //and if the "columnName" column is nullable.
            var stringValue = reader.IsDBNull(reader.GetOrdinal("columnName") 
                            ? "" 
                            : reader.GetString(reader.GetOrdinal("columnName"));
            a.Add(stringValue);
        }
    }
