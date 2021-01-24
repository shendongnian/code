    var utf8 = new UTF8Encoding();
    ...
    string[] columnValues =
        Enumerable.Range(0, numFields)
            .Select(i => {
                if (reader[i].GetType() == typeof(SqlString))
                {
                  SqlString sqlString = reader.GetSqlString(i);
                  Byte[] encodedBytes = sqlString.GetNonUnicodeBytes();
                  return "\"" + utf8.GetString(encodedBytes) + "\"";
                }
                else
                {
                  return "\"" + reader[i].ToString() + "\"";
                }
             }).ToArray();
     ...
