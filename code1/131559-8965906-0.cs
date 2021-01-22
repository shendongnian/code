    public string ReadToJson(SqlDataReader reader)
    {
      List<string> cols = new List<string>(10);
      int ncols = reader.FieldCount;
      for (int i = 0; i < ncols; ++i)
      {
        cols.Add(reader.GetName(i));
      }
      StringBuilder sbJson = new StringBuilder("{");
      //process each row
      while (reader.Read())
      {
        sbJson.Append("{");
        foreach (string col in cols)
        {
          sbJson.AppendFormat("\"{0}\":{1}", col, reader[col]);
        }
        sbJson.Append("},");
      }
      sbJson.Replace("},", "}}", sbJson.Length - 2, 2);
      return sbJson.ToString();
    }
