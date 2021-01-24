    if(m["Capacity"] != null)
    {
      Capacity = new SqlInt64((Int64)m["Capacity"]);
    }
    else
    {
      Capacity = SqlInt64.Null;
    }
