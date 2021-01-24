    Guid guid;
    if(dataReader.HasRows)
    {
        while(dataReader.Read()) 
        {
            if(dataReader["Id"].Equals(DBNull.Value)==false)
            {
                var sid = dataReader["Id"].ToString();
                if(sid.Length > 0 && Guid.TryParse(sid, out guid))
                {
                    d.id = guid;
                }
            }
        }
    }
