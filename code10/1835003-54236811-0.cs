    bool success = Int64.TryParse(Convert.ToString(m["Capacity"]), out long number);
    if (success)
    {
       Capacity = new SqlInt64((Int64)m["Capacity"]);
    }
    else
    {
       Capacity = 0;
    }
