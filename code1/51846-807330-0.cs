    public static String dt2JSON(DataTable dt) {
       StringBuilder s = new StringBuilder("{\"rows\":[");
       bool firstLine = true;
       foreach (DataRow dr in dt.Rows) {
          if (firstLine) {
             firstLine = false;
          } else {
             s.Append(',');
          }
          s.Append('{');
          for (int i = 0; i < dr.Table.Columns.Count; i++) {
             if (i > 0) {
                s.Append(',');
             }
             string name = dt.Columns[i].ColumnName;
             string value = dr[i].ToString();
             s.Append('"')
                .Append(name.Replace("\\","\\\\").Replace("\"","\\\""))
                .Append("\":\"")
                .Append(value.Replace("\\","\\\\").Replace("\"","\\\""))
                .Append('"');
          }
          s.Append("}");
       }
       s.Append("]}");
       return s.ToString();
    }
