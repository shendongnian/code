    ...
    StreamWriter csvFile = new StreamWriter(strOutputFileName, false);
    for (int sheet = 0; sheet < excelsheets.Tables.Count; sheet++)
    {
    ...
      foreach (DataRow row in aSheet.Rows)
      {
          foreach (var column in row.ItemArray)
          {
               csvFile.WriteLine(column.ToString().Replace(",", "&comma;") + ",");
          }
      }
    ...
    }
