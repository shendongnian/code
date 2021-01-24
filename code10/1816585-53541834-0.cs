    foreach(DataTable table in dataset1)
    {
      if(table.TableName == "TableForDataset2")
      {
       dataset2.Tables.Add(table);
      }
    }
