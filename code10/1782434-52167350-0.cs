    var rowLines = new List<string>();
    
    if (reader.Read())
    {
       for (int i = 0; i < reader.FieldCount; i++)
       {
          rowLines.Add(reader.IsDBNull(i) ? string.Empty : reader[i].ToString());
       }
    }
    
    return rowLines.ToArray();
