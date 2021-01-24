    var utf8 = new UTF8Encoding();
    ...
    var result = string.Empty;
    if (reader[i].GetType() == typeof(SqlString))
    {
      SqlString sqlString = reader.GetSqlString(i);
      Byte[] encodedBytes = sqlString.GetNonUnicodeBytes();
      result = "\"" + utf8.GetString(encodedBytes) + "\"";
    }
    else
    {
      result = "\"" + reader[i].ToString() + "\"";
    }
