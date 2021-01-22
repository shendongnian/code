    DataTable Tbl = new DataTable();
    using(StreamReader sr = new StreamReader(path))
    {
      int count = 0;
      string headerRow = sr.Read();
      string[] headers = headerRow.split("\t") //Or ","
      foreach(string h in headers)
      {
        DataColumn dc = new DataColumn(h);
        Tbl.Columns.Add(dc);
        count++;
      }
      while(sr.Peek())
      {
        string data = sr.Read();
        string[] cells = data.Split("\t") 
        DataRow row = new DataRow();
        foreach(string c in cells)
        {
          row.Columns.Add(c);
        }
        Tbl.Rows.Add(row);
      }
    }
