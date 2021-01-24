    public DataTable RemoveDuplicate(DataTable dataTable, string columname)
    {
      Hashtable hashTable = new Hashtable();
      List<String> duplicates = new List<String>();
     foreach (DataRow datarow in dataTable.Rows)
     {
       if (hashTable .Contains(datarow [columname]))
       {
        duplicateList.Add(datarow );
       }
       else
       {
        hashTable .Add(datarow [columname], string.Empty); 
       }
     }
      //Now remove the duplicates .
      foreach (DataRow datarow in duplicates )
      dataTable.Rows.Remove(datarow );
      return dataTable;
    }
