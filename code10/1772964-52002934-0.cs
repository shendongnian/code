    if(rdr2.HasRows)
    {
        if(!rdr2.IsDBNull(colIndex))
           result.Elements.Add(rdr2.GetString(colIndex));
    }
