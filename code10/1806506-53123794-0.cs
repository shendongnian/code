    if (!isColumnCreated)
    {
      for (int i = 0; i < values.Count(); i++)
      {
       table.Columns.Add(values[i]);
       }
       isColumnCreated = true;
       }
     }
    else
    {
      DataRow row = table.NewRow();
      for (int i = 0; i < values.Count(); i++)
      {
      row[i] = values[i];
      }
      table.Rows.Add(row);
    }
